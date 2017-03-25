using Bytes2you.Validation;
using OnlineShop.Libs.DtoModels;
using OnlineShop.Libs.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineShop.Clients.MVC.Controllers
{
    public class ApController : Controller
    {
        private readonly IProductService productService;

        public ApController(IProductService productService)
        {
            Guard.WhenArgument(productService, nameof(productService)).IsNull().Throw();

            this.productService = productService;
        }

        public JsonResult Products(int page = 0, int pageSize = 10)
        {
            var products = this.productService.GetProducts(page, pageSize);

            var result = new { data = products };

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}