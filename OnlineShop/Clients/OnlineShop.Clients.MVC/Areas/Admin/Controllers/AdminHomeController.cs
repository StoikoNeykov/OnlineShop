using OnlineShop.Clients.MVC.Areas.Admin.Controllers.Abstraction;
using System.Web.Mvc;

namespace OnlineShop.Clients.MVC.Areas.Admin.Controllers
{
    public class AdminHomeController : AdminController
    {
        // GET: Admin/AdminHome
        public ActionResult Index()
        {
            return View();
        }
    }
}