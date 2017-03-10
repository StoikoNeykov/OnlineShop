using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Data.Tests.Mocks;
using System.Data.Entity;

namespace OnlineShop.Libs.Data.Tests.EfQuerableTasts
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void THrow_ArgumentNullExceptionWith_ProperMessage_WhenDbSet_IsNull()
        {
            // Arange
            var mockedEntryProvider = new Mock<IEfEntryProvider>();

            // Act & Assert
            Assert.That(() => new EfQuerable<DimmyClass>(null, mockedEntryProvider.Object),
                            Throws.ArgumentNullException.With.Message.Contains("dbSet"));
        }

        [Test]
        public void THrow_ArgumentNullExceptionWith_ProperMessage_WhenEntryProvider_IsNull()
        {
            // Arange
            var mockedDbSet = new Mock<IDbSet<DimmyClass>>();

            // Act & Assert
            Assert.That(() => new EfQuerable<DimmyClass>(mockedDbSet.Object, null),
                            Throws.ArgumentNullException.With.Message.Contains("entryProvider"));
        }

        [Test]
        public void NotTHrow_WhenArguments_AreValid()
        {
            // Arange
            var mockedDbSet = new Mock<IDbSet<DimmyClass>>();
            var mockedEntryProvider = new Mock<IEfEntryProvider>();

            // Act & Assert
            Assert.DoesNotThrow(() => new EfQuerable<DimmyClass>(mockedDbSet.Object, mockedEntryProvider.Object));
        }
    }
}
