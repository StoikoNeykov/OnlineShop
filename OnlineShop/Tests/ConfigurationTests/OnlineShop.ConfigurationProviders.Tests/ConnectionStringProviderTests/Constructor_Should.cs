using NUnit.Framework;
using OnlineShop.ConfigurationProviders.Contracts;

namespace OnlineShop.ConfigurationProviders.Tests.ConnectionStringProviderTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_WhenEnvoirmentProvider_IsNull()
        {
            // Arange, Act & Assert
            Assert.That(() => new ConnectionStringProvider(null),
                                Throws.ArgumentNullException.With.Message.Contains("envoirmentProvider"));
        }
    }
}
