using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Factories;
using System;

namespace OnlineShop.Libs.Data.Tests.OnlineShopDbContextTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_WhenStatefulFactory_IsNull()
        {
            Assert.That(() => new OnlineShopDbContext("any", null),
                                    Throws.ArgumentNullException.With.Message.Contains("StatefulFactory"));
        }

        [TestCase("ecwqce")]
        [TestCase("any")]
        [TestCase("not a string")]
        [TestCase("jsdoa,c24crcewjr,clw")]
        [TestCase("<>@$>@#X@)(<_)X!")]
        public void Call_BaseClassConstructor_WithSame_ConnectionString(string randomString)
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var obj = new OnlineShopDbContext(randomString, mockedFactory.Object);

            StringAssert.Contains(randomString, obj.Database.Connection.ConnectionString);
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("    ")]
        public void Call_BaseClassConstructor_WithSame_ConnectionString_EvenWhenItsInvalid(string invalidString)
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            Assert.That(() => new OnlineShopDbContext(invalidString, mockedFactory.Object),
                                    Throws.ArgumentException.With.Message.Contain("white space"));
        }
    }
}
