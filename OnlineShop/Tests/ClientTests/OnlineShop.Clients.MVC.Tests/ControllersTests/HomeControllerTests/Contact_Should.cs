using NUnit.Framework;
using OnlineShop.Clients.MVC.Controllers;
using TestStack.FluentMVCTesting;

namespace OnlineShop.Clients.MVC.Tests.ControllersTests.HomeControllerTests
{
    [TestFixture]
    public class Contact_Should
    {
        [Test]
        public void RenderDefaultView()
        {
            // Arange
            var obj = new HomeController();

            // Act & Assert
            obj.WithCallTo(x => x.Contact())
                .ShouldRenderDefaultView();
        }
    }
}
