using NUnit.Framework;
using OnlineShop.Libs.Services.Tests.AbstractionTests.BaseServiceTests.Mock;

namespace OnlineShop.Libs.Services.Tests.AbstractionTests.BaseServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithProperMesaage_WhenUnitOfWorkFactoryArgument_IsNull()
        {
            // Act & Assert
            Assert.That(() => new ServiceChildWithSpecificIsValidMethod(null, _ => true),
                Throws.ArgumentNullException.With.Message.Contains("unitOfWorkFactory"));
        }
    }
}
