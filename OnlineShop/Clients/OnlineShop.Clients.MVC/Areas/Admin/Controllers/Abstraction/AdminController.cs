using System.Web.Mvc;

namespace OnlineShop.Clients.MVC.Areas.Admin.Controllers.Abstraction
{
    [Authorize(Roles ="admin")]
    public abstract class AdminController : Controller
    {
    }
}