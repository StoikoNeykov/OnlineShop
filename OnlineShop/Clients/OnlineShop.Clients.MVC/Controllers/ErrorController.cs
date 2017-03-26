using OnlineShop.Clients.MVC.Models;
using OnlineShop.Configuration.Common.Constants;
using System.Web.Mvc;

namespace OnlineShop.Clients.MVC.Controllers
{
    public class ErrorController : Controller
    {
        private const string ErrorView = @"~/Views/Error/Error.cshtml";

        public ActionResult Index()
        {
            var model = new ErrorViewModel()
            {
                ErrorText = "Error",
                ErrorUrl = LocationConstants.ServerErrorImage
            };

            return View(ErrorView, model);
        }

        public ActionResult BadRequest()
        {
            var model = new ErrorViewModel()
            {
                ErrorText = "Error 400 - Bad Request",
                ErrorUrl = LocationConstants.BadRequestImage
            };

            return View(ErrorView, model);
        }

        public ActionResult Unauthorized()
        {
            var model = new ErrorViewModel()
            {
                ErrorText = "Error 401 - Unauthorized",
                ErrorUrl = LocationConstants.UnauthorizedImage
            };

            return View(ErrorView, model);
        }

        public ActionResult NotFound()
        {
            var model = new ErrorViewModel()
            {
                ErrorText = "Error 404 - Not Found",
                ErrorUrl = LocationConstants.NotFoundImage
            };

            return View(ErrorView, model);
        }

        public ActionResult ServerError()
        {
            var model = new ErrorViewModel()
            {
                ErrorText = "Error 500 - Cat Invations",
                ErrorUrl = LocationConstants.ServerErrorImage
            };

            return View(ErrorView, model);
        }
    }
}