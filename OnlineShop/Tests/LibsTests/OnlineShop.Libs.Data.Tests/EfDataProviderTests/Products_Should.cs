using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Data.Factories;
using OnlineShop.Libs.Models;

namespace OnlineShop.Libs.Data.Tests.EfDataProviderTests
{
    public class Products_Should
    {
        [Test]
        public void CallOnce_QuerableFactory_WithDbContext_PassedInConstructor()
        {
            // Arange 
            var mockedDbContext = new Mock<IEfOnlineShopDbContext>();

            var mockedEfQuerable = new Mock<IEfQuerable<Product>>();

            var mockedQuerableFactory = new Mock<IEfQuerableFactory>();
            mockedQuerableFactory.Setup(x => x.GetQuerable<Product>(mockedDbContext.Object))
                                    .Returns(mockedEfQuerable.Object)
                                    .Verifiable();

            var obj = new EfDataProvider(mockedDbContext.Object, mockedQuerableFactory.Object);

            // Act
            var result = obj.Products;

            // Assert
            mockedQuerableFactory.Verify(x => x.GetQuerable<Product>(mockedDbContext.Object),
                                            Times.Once);
        }

        [Test]
        public void Return_QuerableFactory_Result()
        {
            // Arange 
            var mockedDbContext = new Mock<IEfOnlineShopDbContext>();

            var mockedEfQuerable = new Mock<IEfQuerable<Product>>();

            var mockedQuerableFactory = new Mock<IEfQuerableFactory>();
            mockedQuerableFactory.Setup(x => x.GetQuerable<Product>(mockedDbContext.Object))
                                    .Returns(mockedEfQuerable.Object)
                                    .Verifiable();

            var obj = new EfDataProvider(mockedDbContext.Object, mockedQuerableFactory.Object);

            // Act
            var result = obj.Products;

            // Assert
            Assert.AreSame(mockedEfQuerable.Object, result);
        }
    }
}
