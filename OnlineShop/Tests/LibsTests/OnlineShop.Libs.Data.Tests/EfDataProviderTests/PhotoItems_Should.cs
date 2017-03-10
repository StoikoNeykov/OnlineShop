using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Data.Factories;
using OnlineShop.Libs.Models;

namespace OnlineShop.Libs.Data.Tests.EfDataProviderTests
{
    public class PhotoItems_Should
    {
        [Test]
        public void CallOnce_QuerableFactory_WithDbContext_PassedInConstructor()
        {
            // Arange 
            var mockedDbContext = new Mock<IEfOnlineShopDbContext>();

            var mockedEfQuerable = new Mock<IEfQuerable<PhotoItem>>();

            var mockedQuerableFactory = new Mock<IEfQuerableFactory>();
            mockedQuerableFactory.Setup(x => x.GetQuerable<PhotoItem>(mockedDbContext.Object))
                                    .Returns(mockedEfQuerable.Object)
                                    .Verifiable();

            var obj = new EfDataProvider(mockedDbContext.Object, mockedQuerableFactory.Object);

            // Act
            var result = obj.PhotoItems;

            // Assert
            mockedQuerableFactory.Verify(x => x.GetQuerable<PhotoItem>(mockedDbContext.Object),
                                            Times.Once);
        }

        [Test]
        public void Return_QuerableFactory_Result()
        {
            // Arange 
            var mockedDbContext = new Mock<IEfOnlineShopDbContext>();

            var mockedEfQuerable = new Mock<IEfQuerable<PhotoItem>>();

            var mockedQuerableFactory = new Mock<IEfQuerableFactory>();
            mockedQuerableFactory.Setup(x => x.GetQuerable<PhotoItem>(mockedDbContext.Object))
                                    .Returns(mockedEfQuerable.Object)
                                    .Verifiable();

            var obj = new EfDataProvider(mockedDbContext.Object, mockedQuerableFactory.Object);

            // Act
            var result = obj.PhotoItems;

            // Assert
            Assert.AreSame(mockedEfQuerable.Object, result);
        }
    }
}
