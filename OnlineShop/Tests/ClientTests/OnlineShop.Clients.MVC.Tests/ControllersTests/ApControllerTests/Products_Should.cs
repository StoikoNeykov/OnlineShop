using Moq;
using NUnit.Framework;
using OnlineShop.Clients.MVC.Controllers;
using OnlineShop.Libs.DtoModels;
using OnlineShop.Libs.Services.Contracts;
using System.Collections.Generic;
using TestStack.FluentMVCTesting;

namespace OnlineShop.Clients.MVC.Tests.ControllersTests.ApControllerTests
{
    [TestFixture]
    public class Products_Should
    {
        [TestCase(5, 7)]
        [TestCase(111, 2331)]
        [TestCase(958375, 3)]
        public void Call_ProductService_WithSameArguments(int randomPage, int randomPageSize)
        {
            // Arange 
            var mockedService = new Mock<IProductService>();
            mockedService.Setup(x => x.GetProducts(randomPage, randomPageSize)).Verifiable();

            var obj = new ApController(mockedService.Object);

            // Act
            obj.Products(randomPage, randomPageSize);

            // Assert
            mockedService.Verify();
        }

        [TestCase(5, 7)]
        [TestCase(111, 2331)]
        [TestCase(958375, 3)]
        public void ReturnRightJsonResult(int randomPage, int randomPageSize)
        {
            // Arange 
            var mockedService = new Mock<IProductService>();
            mockedService.Setup(x => x.GetProducts(randomPage, randomPageSize)).Returns(new List<ProductSimpleDto>());

            var obj = new ApController(mockedService.Object);

            // Act
            obj.WithCallTo(x => x.Products(randomPage, randomPageSize))
                .ShouldReturnJson();
        }
    }
}
