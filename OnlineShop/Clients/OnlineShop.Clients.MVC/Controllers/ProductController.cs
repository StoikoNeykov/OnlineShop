using System.Web.Mvc;

namespace OnlineShop.Clients.MVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Single(string ProductId)
        {
            if (string.IsNullOrEmpty(ProductId))
            {


            }
            
            return View();
        }
    }
}