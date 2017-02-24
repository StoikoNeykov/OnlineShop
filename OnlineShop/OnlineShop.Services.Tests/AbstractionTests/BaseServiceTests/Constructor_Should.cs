using NUnit.Framework;
using OnlineShop.Services.Tests.AbstractionTests.BaseServiceTests.Mock;

namespace OnlineShop.Services.Tests.AbstractionTests.BaseServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithProperMesaage_WhenUnitOfWorkFactoryArgument_IsNull()
        {
            // Act & Assert
            Assert.That(() => new ServiceChild(null),
                Throws.ArgumentNullException.With.Message.Contains("unitOfWorkFactory"));
        }
    }
}
