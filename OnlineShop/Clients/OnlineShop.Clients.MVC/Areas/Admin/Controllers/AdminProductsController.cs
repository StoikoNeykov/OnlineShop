using Bytes2you.Validation;
using OnlineShop.Clients.MVC.Areas.Admin.Controllers.Abstraction;
using OnlineShop.Clients.MVC.Areas.Admin.Models;
using OnlineShop.Libs.DtoModels;
using OnlineShop.Libs.Services.Contracts;
using System.Web.Mvc;

namespace OnlineShop.Clients.MVC.Areas.Admin.Controllers
{
    public class AdminProductsController : AdminController
    {
        private readonly IProductService productService;
        public AdminProductsController(IProductService productService)
        {
            Guard.WhenArgument(productService, nameof(productService)).IsNull().Throw();

            this.productService = productService;
        }

        // GET: Admin/AdminProducts
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddProduct product)
        {
            if (ModelState.IsValid)
            {
                var productToAdd = new AddProductDto()
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Count = product.Count,
                    Price = product.Price,
                    Photo1 = product.Photo1,
                    Photo2 = product.Photo2,
                    Photo3 = product.Photo3,
                    Photo4 = product.Photo4
                };

                this.productService.Add(productToAdd);
            }

            return View();
        }
    }
}