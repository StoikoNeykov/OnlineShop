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
        public void THrow_ArgumentNullExceptionWith_ProperMessage_WhenDbContext_IsNull()
        {
            // Arange, Act & Assert
            Assert.That(() => new EfQuerable<DimmyClass>(null),
                            Throws.ArgumentNullException.With.Message.Contains("dbContext"));
        }

        [Test]
        public void NotTHrow_WhenArguments_AreValid()
        {
            var mockedDbSet = new Mock<IDbSet<DimmyClass>>();
            
            var mockedDbContext = new Mock<IEfOnlineShopDbContext>();
            mockedDbContext.Setup(x => x.GetSet<DimmyClass>()).Returns(mockedDbSet.Object);

            var obj = new EfQuerable<DimmyClass>(mockedDbContext.Object);
        }
    }
}
