using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Data.Tests.Mocks;
using System.Collections.Generic;
using System.Data.Entity;

namespace OnlineShop.Libs.Data.Tests.EfQuerableTasts
{
    [TestFixture]
    public class GetEnumerator_Should
    {
        [Test]
        public void Return_DbSet_GetAnumerator_Without_ChangeIt()
        {
            // Arange
            var mockedEnumerator = new Mock<IEnumerator<DimmyClass>>();

            var mockedDbSet = new Mock<IDbSet<DimmyClass>>();
            mockedDbSet.Setup(x => x.GetEnumerator()).Returns(mockedEnumerator.Object);

            var mockedEntryProvider = new Mock<IEfEntryProvider>();

            var obj = new EfQuerable<DimmyClass>(mockedDbSet.Object, mockedEntryProvider.Object);

            // Act
            var result = obj.GetEnumerator();

            // Assert
            Assert.AreSame(mockedEnumerator.Object, result);
        }
    }
}
