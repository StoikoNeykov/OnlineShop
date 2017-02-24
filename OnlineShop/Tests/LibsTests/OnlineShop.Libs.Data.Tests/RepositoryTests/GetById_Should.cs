using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Data.Tests.Mocks;
using System;
using System.Data.Entity;
using System.Linq;

namespace OnlineShop.Libs.Data.Tests.RepositoryTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void Should_Work()
        {
            // Arange
            var randomId = Guid.NewGuid();

            var mockedSet = new Mock<IDbSet<DimmyClass>>();
            mockedSet.Setup(x => x.Find(randomId)).Verifiable();

            var mockedContext = new Mock<IOnlineShopDbContext>();
            mockedContext.Setup(x => x.Set<DimmyClass>()).Returns(mockedSet.Object);

            var obj = new Repository<DimmyClass>(mockedContext.Object);

            // Act
            var actual = obj.GetById(randomId);

            // Assert
            mockedSet.Verify();
        }

        [Test]
        public void Should_ThrowArgumentNullException_WithProperMessage_WhenId_IsEmptyGuid()
        {
            // Arange
            var mockedSet = new Mock<IDbSet<DimmyClass>>();

            var mockedContext = new Mock<IOnlineShopDbContext>();
            mockedContext.Setup(x => x.Set<DimmyClass>()).Returns(mockedSet.Object);

            var obj = new Repository<DimmyClass>(mockedContext.Object);

            // Act & Assert
            Assert.That(() => obj.GetById(Guid.Empty),
                                Throws.ArgumentException.With.Message.Contains("Guid.Empty"));
        }
    }
}
