using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Models;
using OnlineShop.Libs.Services.Contracts;
using System;

namespace OnlineShop.Libs.Services.Tests.ProductServiceTests
{
    [TestFixture]
    public class GetProducts_Should
    {
        [TestCase(-6)]
        [TestCase(-441)]
        public void Throw_ArgumentOutOfrangeException_WithProperMessage_WhenPage_IsNotValid(int randomNegativeNumber)
        {
            // Arange 
            var mockedQuerable = new Mock<IEfQuerable<Product>>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            var mockedMapperService = new Mock<IMapperService>();

            var obj = new ProductService(mockedQuerable.Object, mockedUnitOfWork.Object, mockedMapperService.Object);

            // Act & Assert 
            Assert.That(() => obj.GetProducts(randomNegativeNumber),
                            Throws.InstanceOf<ArgumentOutOfRangeException>().With.Message.Contains("page"));
        }

        [TestCase(-6)]
        [TestCase(-441)]
        public void Throw_ArgumentOutOfrangeException_WithProperMessage_WhenPageSize_IsNotValid(int randomNegativeNumber)
        {
            // Arange 
            var validPage = 1;
            var mockedQuerable = new Mock<IEfQuerable<Product>>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            var mockedMapperService = new Mock<IMapperService>();

            var obj = new ProductService(mockedQuerable.Object, mockedUnitOfWork.Object, mockedMapperService.Object);

            // Act & Assert 
            Assert.That(() => obj.GetProducts(validPage, randomNegativeNumber),
                            Throws.InstanceOf<ArgumentOutOfRangeException>().With.Message.Contains("page"));
        }
    }
}
