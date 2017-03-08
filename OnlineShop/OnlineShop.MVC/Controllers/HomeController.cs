using OnlineShop.Configuration.Common.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Basic()
        {
            return this.RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var path = Server.MapPath(LocationConstants.CarouselItemsFolder);

            var files = Directory.GetFiles(path)
                    .Select(x => LocationConstants.CarouselItemsFolder + x.Substring(x.LastIndexOf("\\")));

            ViewBag.Files = files;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}