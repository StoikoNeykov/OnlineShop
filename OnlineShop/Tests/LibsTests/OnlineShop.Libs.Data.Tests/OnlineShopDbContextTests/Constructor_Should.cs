using Moq;
using NUnit.Framework;
using OnlineShop.ConfigurationProviders;
using System;

namespace OnlineShop.Libs.Data.Tests.OnlineShopDbContextTests
{
    [TestFixture]
    public class Constructor_Should
    {
        private string validConnectionString = new ConnectionStringProvider(new EnvoirmentProvider()).ConnectionString;

        [TestCase("ecwqce")]
        [TestCase("anything else")]
        [TestCase("not a string")]
        [TestCase("jsdoa,c24crcewjr,clw")]
        [TestCase("<>@$>@#X@)(<_)X!")]
        public void Call_BaseClassConstructor_WithSame_ConnectionString(string randomString)
        {
            // Act
            var obj = new OnlineShopDbContext(randomString);

            // Assert
            StringAssert.Contains(randomString, obj.Database.Connection.ConnectionString);
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("    ")]
        public void Call_BaseClassConstructor_WithSame_ConnectionString_EvenWhenItsInvalid(string invalidString)
        {
            // Act & Assert
            Assert.That(() => new OnlineShopDbContext(invalidString),
                                    Throws.ArgumentException.With.Message.Contain("white space"));
        }
    }
}
