using OnlineShop.Clients.MVC.Models;
using OnlineShop.Configuration.Common.Constants;
using System.Web.Mvc;

namespace OnlineShop.Clients.MVC.Controllers
{
    public class ErrorController : Controller
    {

        public ActionResult Index()
        {
            var model = new ErrorViewModel()
            {
                ErrorText = TextConstants.Error,
                ErrorUrl = LocationConstants.ServerErrorImage
            };

            return View(TextConstants.ErrorView, model);
        }

        public ActionResult BadRequest()
        {
            var model = new ErrorViewModel()
            {
                ErrorText = TextConstants.Error400,
                ErrorUrl = LocationConstants.BadRequestImage
            };

            return View(TextConstants.ErrorView, model);
        }

        public ActionResult Unauthorized()
        {
            var model = new ErrorViewModel()
            {
                ErrorText = TextConstants.Error401,
                ErrorUrl = LocationConstants.UnauthorizedImage
            };

            return View(TextConstants.ErrorView, model);
        }

        public ActionResult NotFound()
        {
            var model = new ErrorViewModel()
            {
                ErrorText = TextConstants.Error404,
                ErrorUrl = LocationConstants.NotFoundImage
            };

            return View(TextConstants.ErrorView, model);
        }

        public ActionResult ServerError()
        {
            var model = new ErrorViewModel()
            {
                ErrorText = TextConstants.Error500,
                ErrorUrl = LocationConstants.ServerErrorImage
            };

            return View(TextConstants.ErrorView, model);
        }
    }
}