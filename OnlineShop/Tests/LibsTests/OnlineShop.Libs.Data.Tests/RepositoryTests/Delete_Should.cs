using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Data.Tests.Mocks;
using System.Data.Entity;

namespace OnlineShop.Libs.Data.Tests.RepositoryTests
{
    [TestFixture]
    public class Delete_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_WhenEntity_IsNull()
        {
            var mockedSet = new Mock<IDbSet<DimmyClass>>();
            var mockedStateful = new Mock<IStateful<DimmyClass>>();

            var mockedContext = new Mock<IOnlineShopDbContext>();
            mockedContext.Setup(x => x.Set<DimmyClass>()).Returns(mockedSet.Object);
            mockedContext.Setup(x => x.GetStateful<DimmyClass>(It.IsAny<DimmyClass>())).Returns(mockedStateful.Object);

            var obj = new Repository<DimmyClass>(mockedContext.Object);

            Assert.That(() => obj.Delete(null),
                                   Throws.ArgumentNullException.With.Message.Contains("Entity"));
        }

        [Test]
        public void Change_StatefulState_ToDeleted()
        {
            var mockedSet = new Mock<IDbSet<DimmyClass>>();

            var mockedStateful = new Mock<IStateful<DimmyClass>>();
            mockedStateful.SetupSet(x => x.State = EntityState.Deleted).Verifiable();

            var mockedContext = new Mock<IOnlineShopDbContext>();
            mockedContext.Setup(x => x.Set<DimmyClass>()).Returns(mockedSet.Object);
            mockedContext.Setup(x => x.GetStateful<DimmyClass>(It.IsAny<DimmyClass>())).Returns(mockedStateful.Object);

            var obj = new Repository<DimmyClass>(mockedContext.Object);

            obj.Delete(new DimmyClass());

            mockedStateful.Verify();
        }
    }
}
