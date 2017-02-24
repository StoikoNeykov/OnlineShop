using Moq;
using NUnit.Framework;
using OnlineShop.ConfigurationProviders;
using OnlineShop.Libs.Data.Factories;
using System;

namespace OnlineShop.Libs.Data.Tests.OnlineShopDbContextTests
{
    [TestFixture]
    public class Constructor_Should
    {
        private string validConnectionString = new ConnectionStringProvider(new EnvoirmentProvider()).ConnectionString;

        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_WhenStatefulFactory_IsNull()
        {
            // Act & Assert
            Assert.That(() => new OnlineShopDbContext(this.validConnectionString, null),
                                    Throws.ArgumentNullException.With.Message.Contains("StatefulFactory"));
        }

        [TestCase("ecwqce")]
        [TestCase("anything else")]
        [TestCase("not a string")]
        [TestCase("jsdoa,c24crcewjr,clw")]
        [TestCase("<>@$>@#X@)(<_)X!")]
        public void Call_BaseClassConstructor_WithSame_ConnectionString(string randomString)
        {
            // Arange 
            var mockedFactory = new Mock<IStatefulFactory>();

            // Act
            var obj = new OnlineShopDbContext(randomString, mockedFactory.Object);

            // Assert
            StringAssert.Contains(randomString, obj.Database.Connection.ConnectionString);
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("    ")]
        public void Call_BaseClassConstructor_WithSame_ConnectionString_EvenWhenItsInvalid(string invalidString)
        {
            // Arange
            var mockedFactory = new Mock<IStatefulFactory>();

            // Act & Assert
            Assert.That(() => new OnlineShopDbContext(invalidString, mockedFactory.Object),
                                    Throws.ArgumentException.With.Message.Contain("white space"));
        }
    }
}
