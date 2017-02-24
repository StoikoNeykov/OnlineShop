using System;
using NUnit.Framework;
using OnlineShop.Libs.Models.Contracts;
using Moq;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Data.Tests.Mocks;

namespace OnlineShop.Libs.Data.Tests.RepositoryTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_NullReferenceException_WithProeperMessage_WhenDbContext_IsNull()
        {
            Assert.That(() => new Repository<DimmyClass>(null),
                                    Throws.ArgumentNullException.With.Message.Contains("dbContext"));
        }

        [Test]
        public void Throw_NullReferenceException_WithProeperMessage_WhenDbContext_ReturnNullForSet()
        {
            var mockedContext = new Mock<IOnlineShopDbContext>();
            mockedContext.Setup(x => x.Set<DimmyClass>()).Returns<DimmyClass>(null);

            Assert.That(() => new Repository<DimmyClass>(mockedContext.Object),
                                    Throws.ArgumentNullException.With.Message.Contains("dbSet"));
        }

        [Test]
        public void NotCatch_Exception_ThrownFromDbContext_SetMethod()
        {
            var mockedContext = new Mock<IOnlineShopDbContext>();
            mockedContext.Setup(x => x.Set<DimmyClass>()).Throws<Exception>();

            Assert.That(() => new Repository<DimmyClass>(mockedContext.Object),
                                    Throws.Exception);
        }
    }
}
