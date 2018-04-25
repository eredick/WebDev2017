using log4net;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cibertec.Mvc.Controllers
{
    public class HomeController : Controller
    {
        protected readonly ILog _log;
        public HomeController(ILog log)
        {
            _log = log;
        }

        public ActionResult Index()
        {
            _log.Info("prueba");
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

        public ActionResult Tests()
        {
            return View();
        }

        public ActionResult Unauthorized()
        {
            Response.StatusCode = 403;
            return View();
        }
    }
}