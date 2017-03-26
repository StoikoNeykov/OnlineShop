using Moq;
using NUnit.Framework;
using OnlineShop.Clients.MVC.Controllers;
using OnlineShop.Libs.DtoModels;
using OnlineShop.Libs.Services.Contracts;
using TestStack.FluentMVCTesting;

namespace OnlineShop.Clients.MVC.Tests.ControllersTests.ProductControllerTests
{
    [TestFixture]
    public class Single_Should
    {
        [TestCase(null)]
        [TestCase("")]
        public void RedirectToErrorPage_WhenArgument_IsNullOrEmpty(string NullOrEmptyString)
        {
            // Arange 
            var mockedProductService = new Mock<IProductService>();

            var obj = new ProductController(mockedProductService.Object);

            // Act & Assert
            obj.WithCallTo(x => x.Single(NullOrEmptyString))
                .ShouldRedirectTo("/Error/BadRequest");
        }

        [TestCase("randomstring")]
        [TestCase("ewcqecqw")]
        [TestCase("123<>#21")]
        public void Call_ProductService_GetByNameMethod_WithSameString(string randomString)
        {
            // Arange 
            var mockedProductService = new Mock<IProductService>();
            mockedProductService.Setup(x => x.GetByName(randomString)).Verifiable();

            var obj = new ProductController(mockedProductService.Object);

            // Act
            obj.Single(randomString);

            // Assert
            mockedProductService.Verify();
        }

        [Test]
        public void RenderDefaultView()
        {
            // Arange 
            var randomString = "xewqxe211";

            var mockedProductService = new Mock<IProductService>();
            mockedProductService.Setup(x => x.GetByName(randomString));

            var obj = new ProductController(mockedProductService.Object);

            // Act & Assert
            obj.WithCallTo(x => x.Single(randomString))
                .ShouldRenderDefaultView();
        }

        [Test]
        public void RenderDefaultView_WithRightModel()
        {
            // Arange 
            var randomString = "xewqxe211";
            var expectedDto = new ProductDto()
            {
                Photo1 = "555",
                Name = "Name"
            };

            var mockedProductService = new Mock<IProductService>();
            mockedProductService.Setup(x => x.GetByName(randomString)).Returns(expectedDto);

            var obj = new ProductController(mockedProductService.Object);

            // Act & Assert
            obj.WithCallTo(x => x.Single(randomString))
                .ShouldRenderDefaultView()
                .WithModel<ProductDto>(expectedDto);
        }
    }
}
