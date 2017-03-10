using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Data.Factories;
using System.Threading.Tasks;

namespace OnlineShop.Libs.Data.Tests.EfDataProviderTests
{
    [TestFixture]
    public class SaveChangesAsync_Should
    {
        [Test]
        public void CallOnce_DbContext_SaveChanges()
        {
            // Arange 
            var mockedQuerableFactory = new Mock<IEfQuerableFactory>();
            var mockedDbContext = new Mock<IEfOnlineShopDbContext>();
            mockedDbContext.Setup(x => x.SaveChangesAsync()).Verifiable();

            var obj = new EfDataProvider(mockedDbContext.Object, mockedQuerableFactory.Object);

            // Act
            obj.SaveChangesAsync();

            // Assert
            mockedDbContext.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        /// <summary>
        /// Not coz its important - coz could be
        /// </summary>
        [TestCase(0)]
        [TestCase(-7773)]
        [TestCase(1144113)]
        public void ReturnResultComesFrom_DbContext_SaveChanges(int randomNumber)
        {
            // Arange 
            var mockedQuerableFactory = new Mock<IEfQuerableFactory>();
            var mockedDbContext = new Mock<IEfOnlineShopDbContext>();
            mockedDbContext.Setup(x => x.SaveChangesAsync()).Returns(Task.FromResult(randomNumber));

            var obj = new EfDataProvider(mockedDbContext.Object, mockedQuerableFactory.Object);

            // Act
            var result = obj.SaveChangesAsync().Result;

            // Assert
            Assert.AreEqual(randomNumber, result);
        }
    }
}
