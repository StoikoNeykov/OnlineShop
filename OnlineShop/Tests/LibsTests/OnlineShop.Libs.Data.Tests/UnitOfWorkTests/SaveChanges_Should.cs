using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;

namespace OnlineShop.Libs.Data.Tests.UnitOfWorkTests
{
    [TestFixture]
    public class SaveChanges_Should
    {
        [Test]
        public void Call_DbContext_SaveChanges()
        {
            var mockedContext = new Mock<IOnlineShopDbContext>();
            mockedContext.Setup(x => x.SaveChanges()).Verifiable();

            var obj = new UnitOfWork(mockedContext.Object);
            obj.SaveChanges();

            mockedContext.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
