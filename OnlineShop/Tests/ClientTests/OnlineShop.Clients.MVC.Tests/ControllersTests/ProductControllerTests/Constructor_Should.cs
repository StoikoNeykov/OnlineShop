using NUnit.Framework;
using OnlineShop.Clients.MVC.Controllers;

namespace OnlineShop.Clients.MVC.Tests.ControllersTests.ProductControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_ProductService_IsNull()
        {
            // Arrange, Act, Assert
            Assert.That(() => new ProductController(null),
                            Throws.ArgumentNullException.With.Message.Contains("productService"));
        }
    }
}
