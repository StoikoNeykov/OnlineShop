using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Data.Tests.Mocks;
using System.Data.Entity;
using System.Linq;

namespace OnlineShop.Libs.Data.Tests.EfQuerableTasts
{
    [TestFixture]
    public class Provider_Should
    {
        [Test]
        public void Return_DbSet_Provider_Without_ChangeIt()
        {
            // Arange
            var mockedProvider = new Mock<IQueryProvider>();

            var mockedDbSet = new Mock<IDbSet<DimmyClass>>();
            mockedDbSet.Setup(x => x.Provider).Returns(mockedProvider.Object);

            var mockedEntryProvider = new Mock<IEfEntryProvider>();

            var obj = new EfQuerable<DimmyClass>(mockedDbSet.Object, mockedEntryProvider.Object);

            // Act
            var result = obj.Provider;

            // Assert
            Assert.AreSame(mockedProvider.Object, result);
        }
    }
}
