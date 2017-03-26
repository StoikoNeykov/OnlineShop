using NUnit.Framework;
using OnlineShop.Clients.MVC.Controllers;
using OnlineShop.Clients.MVC.Models;
using OnlineShop.Configuration.Common.Constants;
using TestStack.FluentMVCTesting;

namespace OnlineShop.Clients.MVC.Tests.ControllersTests.ErrorControllerTests
{
    [TestFixture]
    public class ServerError_Should
    {
        [Test]
        public void RenderRightView()
        {
            // Arange

            var obj = new ErrorController();

            // Act & Assert
            obj.WithCallTo(x => x.ServerError())
                .ShouldRenderView(TextConstants.ErrorView);
        }

        [Test]
        public void ConstructRightModel_AndPassItToView()
        {
            // Arange
            var obj = new ErrorController();

            // Act & Assert
            obj.WithCallTo(x => x.ServerError())
                .ShouldRenderView(TextConstants.ErrorView)
                .WithModel<ErrorViewModel>(x => x.ErrorText == TextConstants.Error500 &&
                                                x.ErrorUrl == LocationConstants.ServerErrorImage);
        }
    }
}
