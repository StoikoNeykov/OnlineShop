using Bytes2you.Validation;
using OnlineShop.Libs.Services.Contracts;
using System.Web.Mvc;

namespace OnlineShop.Clients.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            Guard.WhenArgument(productService, nameof(productService)).IsNull().Throw();

            this.productService = productService;
        }

        public ActionResult Single(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return this.Redirect("/Error/BadRequest");
            }

            var product = this.productService.GetByName(name);

            return View(product);
        }
    }
}