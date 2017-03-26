using NUnit.Framework;
using OnlineShop.Clients.MVC.Controllers;
using TestStack.FluentMVCTesting;

namespace OnlineShop.Clients.MVC.Tests.ControllersTests.HomeControllerTests
{
    [TestFixture]
    public class Basic_Should
    {
        [Test]
        public void RedirectToIndex()
        {
            // Arange 
            var obj = new HomeController();

            // Act & Assert
            obj.WithCallTo(x => x.Basic())
                .ShouldRedirectTo(x => x.Index());
        }
    }
}
