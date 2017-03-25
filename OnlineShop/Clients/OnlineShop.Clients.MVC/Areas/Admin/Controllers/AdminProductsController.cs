using OnlineShop.Clients.MVC.Areas.Admin.Controllers.Abstraction;
using System.Web.Mvc;

namespace OnlineShop.Clients.MVC.Areas.Admin.Controllers
{
    public class AdminProductsController : AdminController
    {
        // GET: Admin/AdminProducts
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(int g)
        {
            return View();
        }
    }
}