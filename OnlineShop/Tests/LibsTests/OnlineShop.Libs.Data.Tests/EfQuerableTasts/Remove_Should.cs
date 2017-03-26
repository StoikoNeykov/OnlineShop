using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Data.Tests.Mocks;
using System.Data.Entity;

namespace OnlineShop.Libs.Data.Tests.EfQuerableTasts
{
    public class Remove_Should
    {
        [Test]
        public void CallOnce_DbSet_Remove_WithSameArguments()
        {
            // Arange
            var mockedDbModel = new DimmyClass();

            var mockedDbSet = new Mock<IDbSet<DimmyClass>>();
            mockedDbSet.Setup(x => x.Remove(mockedDbModel)).Verifiable();

            var mockedDbContext = new Mock<IEfOnlineShopDbContext>();
            mockedDbContext.Setup(x => x.GetSet<DimmyClass>()).Returns(mockedDbSet.Object);

            var obj = new EfQuerable<DimmyClass>(mockedDbContext.Object);

            // Act
            obj.Remove(mockedDbModel);

            // Assert
            mockedDbSet.Verify(x => x.Remove(mockedDbModel), Times.Once);
        }

        [Test]
        public void Throw_ArgumentNullException_WIthProperMessage_WhenEntity_IsNull()
        {
            // Arange
            var mockedDbSet = new Mock<IDbSet<DimmyClass>>();

            var mockedDbContext = new Mock<IEfOnlineShopDbContext>();
            mockedDbContext.Setup(x => x.GetSet<DimmyClass>()).Returns(mockedDbSet.Object);

            var obj = new EfQuerable<DimmyClass>(mockedDbContext.Object);

            // Act & Assert
            Assert.That(() => obj.Remove(null),
                            Throws.ArgumentNullException.With.Message.Contains("entity"));

        }
    }
}
