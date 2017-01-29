using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Data.Tests.Mocks;
using System.Data.Entity;
using System.Linq;

namespace OnlineShop.Libs.Data.Tests.RepositoryTests
{
    [TestFixture]
    public class GetById_Should
    {
        [TestCase(5)]
        [TestCase(3)]
        [TestCase(21)]
        [TestCase(6)]
        public void Should_Work(int randomId)
        {
            var mockedSet = new Mock<IDbSet<DimmyClass>>();
            mockedSet.Setup(x => x.Find(randomId)).Verifiable();

            var mockedContext = new Mock<IOnlineShopDbContext>();
            mockedContext.Setup(x => x.Set<DimmyClass>()).Returns(mockedSet.Object);

            var obj = new Repository<DimmyClass>(mockedContext.Object);

            var actual = obj.GetById(randomId);

            mockedSet.Verify();
        }

        [Test]
        public void Should_ThrowArgumentNullException_WithProperMessage_WhenId_IsNull()
        {
            var mockedSet = new Mock<IDbSet<DimmyClass>>();

            var mockedContext = new Mock<IOnlineShopDbContext>();
            mockedContext.Setup(x => x.Set<DimmyClass>()).Returns(mockedSet.Object);

            var obj = new Repository<DimmyClass>(mockedContext.Object);

            Assert.That(() => obj.GetById(null),
                                Throws.ArgumentNullException.With.Message.Contains("Id"));
        }
    }
}
