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

            var mockedEntryProvider = new Mock<IEfEntryProvider>();

            var obj = new EfQuerable<DimmyClass>(mockedDbSet.Object, mockedEntryProvider.Object);

            // Act
            obj.Remove(mockedDbModel);

            // Assert
            mockedDbSet.Verify(x => x.Remove(mockedDbModel), Times.Once);
        }
    }
}
