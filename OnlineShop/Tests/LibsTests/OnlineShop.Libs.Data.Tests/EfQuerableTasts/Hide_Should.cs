using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Data.Tests.Mocks;
using System.Data.Entity;

namespace OnlineShop.Libs.Data.Tests.EfQuerableTasts
{
    [TestFixture]
    public class Hide_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WIthProperMessage_WhenEntity_IsNull()
        {
            // Arange
            var mockedDbSet = new Mock<IDbSet<DimmyClass>>();

            var mockedDbContext = new Mock<IEfOnlineShopDbContext>();
            mockedDbContext.Setup(x => x.GetSet<DimmyClass>()).Returns(mockedDbSet.Object);

            var obj = new EfQuerable<DimmyClass>(mockedDbContext.Object);

            // Act & Assert
            Assert.That(() => obj.Hide(null),
                            Throws.ArgumentNullException.With.Message.Contains("entity"));

        }
    }
}
