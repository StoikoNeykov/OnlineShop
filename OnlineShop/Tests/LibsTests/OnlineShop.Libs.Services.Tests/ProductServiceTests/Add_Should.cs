using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Models;
using OnlineShop.Libs.Services.Contracts;
using OnlineShop.Libs.Services.Tests.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Libs.Services.Tests.ProductServiceTests
{
    [TestFixture]
    public class Add_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_WhenArgumentIsNull()
        {
            // Arange 
            var mockedQuerable = new Mock<IEfQuerable<Product>>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            var mockedMapperService = new Mock<IMapperService>();

            var obj = new ProductService(mockedQuerable.Object, mockedUnitOfWork.Object, mockedMapperService.Object);

            // Act & Assert 
            Assert.That(() => obj.Add(null),
                                Throws.ArgumentNullException.With.Message.Contains("product"));
        }

        [Test]
        public void Call_MapperService_MapMethod_WithSameProduct_WhenProductIsValid()
        {
            // Arange 
            var product = ProductGenerator.GetProductDtos(1).First();

            var mockedQuerable = new Mock<IEfQuerable<Product>>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();

            var mockedMapperService = new Mock<IMapperService>();
            mockedMapperService.Setup(x => x.Map(product)).Verifiable();

            var obj = new ProductService(mockedQuerable.Object, mockedUnitOfWork.Object, mockedMapperService.Object);

            // Act
            obj.Add(product);

            // Assert
            mockedMapperService.Verify(x => x.Map(product), Times.Once);
        }

        [Test]
        public void Call_Querable_AddMethod_WithSameProduct_ReturnedFromMapperService_WhenProductIsValid()
        {
            // Arange 
            var productDto = ProductGenerator.GetProductDtos(1).First();
            var product = ProductGenerator.GetProducts(1).First();

            var mockedQuerable = new Mock<IEfQuerable<Product>>();
            mockedQuerable.Setup(x => x.Add(product)).Verifiable();

            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();

            var mockedMapperService = new Mock<IMapperService>();
            mockedMapperService.Setup(x => x.Map(productDto)).Returns(product);

            var obj = new ProductService(mockedQuerable.Object, mockedUnitOfWork.Object, mockedMapperService.Object);

            // Act
            obj.Add(productDto);

            // Assert
            mockedQuerable.Verify(x => x.Add(product), Times.Once);
        }

        [Test]
        public void Call_UnitOfWork_SaveChangesMethod_WhenProductIsValid()
        {
            // Arange 
            var productDto = ProductGenerator.GetProductDtos(1).First();
            var product = ProductGenerator.GetProducts(1).First();

            var mockedQuerable = new Mock<IEfQuerable<Product>>();
            mockedQuerable.Setup(x => x.Add(product));

            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            mockedUnitOfWork.Setup(x => x.SaveChanges()).Verifiable();

            var mockedMapperService = new Mock<IMapperService>();
            mockedMapperService.Setup(x => x.Map(productDto)).Returns(product);

            var obj = new ProductService(mockedQuerable.Object, mockedUnitOfWork.Object, mockedMapperService.Object);

            // Act
            obj.Add(productDto);

            // Assert
            mockedUnitOfWork.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Test]
        public void Call_UnitOfWork_SaveChangesMethod_AfterAddInQuerable()
        {
            // Arange 
            var expected = new List<int>() { 1, 2 };
            var actual = new List<int>();

            var productDto = ProductGenerator.GetProductDtos(1).First();
            var product = ProductGenerator.GetProducts(1).First();

            var mockedQuerable = new Mock<IEfQuerable<Product>>();
            mockedQuerable.Setup(x => x.Add(product)).Callback(()=>actual.Add(1));

            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            mockedUnitOfWork.Setup(x => x.SaveChanges()).Callback(()=>actual.Add(2));

            var mockedMapperService = new Mock<IMapperService>();
            mockedMapperService.Setup(x => x.Map(productDto)).Returns(product);

            var obj = new ProductService(mockedQuerable.Object, mockedUnitOfWork.Object, mockedMapperService.Object);

            // Act
            obj.Add(productDto);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
