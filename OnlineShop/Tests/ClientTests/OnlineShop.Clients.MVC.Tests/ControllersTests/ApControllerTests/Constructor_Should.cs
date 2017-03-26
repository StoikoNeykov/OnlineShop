using NUnit.Framework;
using OnlineShop.Clients.MVC.Controllers;

namespace OnlineShop.Clients.MVC.Tests.ControllersTests.ApControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_WhenProductService_IsNull()
        {
            // Arange, Act & Assert
            Assert.That(() => new ApController(null),
                                Throws.ArgumentNullException.With.Message.Contains("productService"));
        }
    }
}
