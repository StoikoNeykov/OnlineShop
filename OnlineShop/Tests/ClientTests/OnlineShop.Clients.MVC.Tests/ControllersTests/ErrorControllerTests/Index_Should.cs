using NUnit.Framework;
using OnlineShop.Clients.MVC.Controllers;
using OnlineShop.Clients.MVC.Models;
using OnlineShop.Configuration.Common.Constants;
using TestStack.FluentMVCTesting;

namespace OnlineShop.Clients.MVC.Tests.ControllersTests.ErrorControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void Should_Render_RightView()
        {
            // Arange

            var obj = new ErrorController();

            // Act & Assert
            obj.WithCallTo(x => x.Index())
                .ShouldRenderView(TextConstants.ErrorView);
        }

        [Test]
        public void ConstructRightModel_AndPassItToView()
        {
            // Arange
            var obj = new ErrorController();

            // Act & Assert
            obj.WithCallTo(x => x.Index())
                .ShouldRenderView(TextConstants.ErrorView)
                .WithModel<ErrorViewModel>(x => x.ErrorText == TextConstants.Error && 
                                                x.ErrorUrl == LocationConstants.ServerErrorImage);
        }
    }
}
