using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Models;
using OnlineShop.Libs.Models.Contracts;
using OnlineShop.Libs.Services.Tests.Helpers;
using System.Collections.Generic;

namespace OnlineShop.Libs.Services.Tests.ProductServiceTests
{
    [TestFixture]
    public class GetProducts_Should
    {
        [Test]
        public void Use_Products_GetAvailableProperty()
        {
            // Arange
            var collection = new List<Product>();

            var mockedQuerable = QuerableMock.GetQuetableMock(collection);
            mockedQuerable.Setup(x => x.GetAvailabe).Returns(mockedQuerable.Object).Verifiable();

            var mockedDataProvider = new Mock<IEfDataProvider>();
            mockedDataProvider.Setup(x => x.Products).Returns(mockedQuerable.Object);

            var obj = new ProductService(mockedDataProvider.Object);

            // Act 
            obj.GetProducts(0, 10);

            // Act, Assert
            mockedQuerable.VerifyGet(x => x.GetAvailabe, Times.Once);
        }
    }
}
