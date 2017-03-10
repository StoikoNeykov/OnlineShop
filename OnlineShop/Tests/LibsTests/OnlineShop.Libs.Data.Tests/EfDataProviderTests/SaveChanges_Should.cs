using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Data.Factories;

namespace OnlineShop.Libs.Data.Tests.EfDataProviderTests
{
    [TestFixture]
    public class SaveChanges_Should
    {
        [Test]
        public void CallOnce_DbContext_SaveChanges()
        {
            // Arange 
            var mockedQuerableFactory = new Mock<IEfQuerableFactory>();
            var mockedDbContext = new Mock<IEfOnlineShopDbContext>();
            mockedDbContext.Setup(x => x.SaveChanges()).Verifiable();

            var obj = new EfDataProvider(mockedDbContext.Object, mockedQuerableFactory.Object);

            // Act
            obj.SaveChanges();

            // Assert
            mockedDbContext.Verify(x => x.SaveChanges(), Times.Once);
        }

        /// <summary>
        /// Not coz its important - coz could be
        /// </summary>
        [TestCase(0)]
        [TestCase(-693)]
        [TestCase(9851553)]
        public void ReturnResultComesFrom_DbContext_SaveChanges(int randomNumber)
        {
            // Arange 
            var mockedQuerableFactory = new Mock<IEfQuerableFactory>();
            var mockedDbContext = new Mock<IEfOnlineShopDbContext>();
            mockedDbContext.Setup(x => x.SaveChanges()).Returns(randomNumber);

            var obj = new EfDataProvider(mockedDbContext.Object, mockedQuerableFactory.Object);

            // Act
            var result = obj.SaveChanges();

            // Assert
            Assert.AreEqual(randomNumber, result);
        }
    }
}
