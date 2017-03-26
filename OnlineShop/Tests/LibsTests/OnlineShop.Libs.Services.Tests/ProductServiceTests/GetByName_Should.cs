using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Models;
using OnlineShop.Libs.Services.Contracts;
using OnlineShop.Libs.Services.Tests.Helpers;
using System.Linq;

namespace OnlineShop.Libs.Services.Tests.ProductServiceTests
{
    [TestFixture]
    public class GetByName_Should
    {
        [TestCase(null)]
        [TestCase("")]
        public void Return_Null_WhenArgument_IsNullOrEmpty(string NullOrEmptyString)
        {
            // Arange 
            var mockedQuerable = new Mock<IEfQuerable<Product>>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            var mockedMapperService = new Mock<IMapperService>();

            var obj = new ProductService(mockedQuerable.Object, mockedUnitOfWork.Object, mockedMapperService.Object);

            // Act
            var result = obj.GetByName(NullOrEmptyString);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Call_Querable_FirstOrDefault_WithSameName()
        {
            // Arange 
            var randomNumberOfProducts = 10;
            var randomNumberInsideCollection = 4;

            var collection = ProductGenerator.GetProducts(randomNumberOfProducts);
            var randomItem = collection.ToList()[randomNumberInsideCollection];
            var randomName = randomItem.Name;

            var randomDto = ProductGenerator.GetProductDtos(1).First();

            var mockedQuerable = QuerableMock.GetQuetableMock(collection);

            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();

            var mockedMapperService = new Mock<IMapperService>();
            mockedMapperService.Setup(x => x.Map(randomItem)).Returns(randomDto);

            var obj = new ProductService(mockedQuerable.Object, mockedUnitOfWork.Object, mockedMapperService.Object);

            // Act
            var result = obj.GetByName(randomName);

            // Assert
            Assert.AreSame(randomDto, result);
        }

        [Test]
        public void Call_Querable_FirstOrDefault_WithSameName_ButNameWontBeFoundInCollection()
        {
            // Arange 
            var randomNumberOfProducts = 10;
            var randomNumberInsideCollection = 4;

            var collection = ProductGenerator.GetProducts(randomNumberOfProducts);
            var randomItem = collection.ToList()[randomNumberInsideCollection];
            var randomName = randomItem.Name + "the string that will fail finding the name in the collection";
            
            var mockedQuerable = QuerableMock.GetQuetableMock(collection);

            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();

            var mockedMapperService = new Mock<IMapperService>();
            mockedMapperService.Setup(x => x.Map((Product)null)).Verifiable();

            var obj = new ProductService(mockedQuerable.Object, mockedUnitOfWork.Object, mockedMapperService.Object);

            // Act
            var result = obj.GetByName(randomName);

            // Assert
            mockedMapperService.Verify();
        }
    }
}
