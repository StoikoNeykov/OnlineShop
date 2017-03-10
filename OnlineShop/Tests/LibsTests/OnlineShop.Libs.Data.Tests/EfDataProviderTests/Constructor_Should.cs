using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Data.Factories;

namespace OnlineShop.Libs.Data.Tests.EfDataProviderTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_WhenDbContext_IsNull()
        {
            // Arange 
            var mockedQuerableFactory = new Mock<IEfQuerableFactory>();

            // Act & Assert
            Assert.That(() => new EfDataProvider(null, mockedQuerableFactory.Object),
                            Throws.ArgumentNullException.With.Message.Contains("dbContext"));
        }

        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_WhenQuerableFactory_IsNull()
        {
            // Arange 
            var mockedDbContext = new Mock<IOnlineShopEfDbContext>();

            // Act & Assert
            Assert.That(() => new EfDataProvider(mockedDbContext.Object, null),
                            Throws.ArgumentNullException.With.Message.Contains("querableFactory"));
        }

        [Test]
        public void NotThrow_WhenArguments_AreValid()
        {
            // Arange 
            var mockedQuerableFactory = new Mock<IEfQuerableFactory>();
            var mockedDbContext = new Mock<IOnlineShopEfDbContext>();

            // Act & Assert
            Assert.DoesNotThrow(() => new EfDataProvider(mockedDbContext.Object, mockedQuerableFactory.Object));
        }
    }
}
