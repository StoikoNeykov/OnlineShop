using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;

namespace OnlineShop.Libs.Data.Tests.UnitOfWorkTests
{
    [TestFixture]
    public class SaveChangesAsync_Should
    {
        [Test]
        public void Call_DbContext_SaveChangesAsync()
        {
            // Arange
            var mockedContext = new Mock<IOnlineShopDbContext>();
            mockedContext.Setup(x => x.SaveChangesAsync()).Verifiable();

            var obj = new UnitOfWork(mockedContext.Object);

            // Act
            obj.SaveChangesAsync();

            // Assert
            mockedContext.Verify(x => x.SaveChangesAsync(), Times.Once);
        }
    }
}
