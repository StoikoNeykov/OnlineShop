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
            var mockedContext = new Mock<IOnlineShopDbContext>();
            mockedContext.Setup(x => x.SaveChangesAsync()).Verifiable();

            var obj = new UnitOfWork(mockedContext.Object);
            obj.SaveChangesAsync();

            mockedContext.Verify(x => x.SaveChangesAsync(), Times.Once);
        }
    }
}
