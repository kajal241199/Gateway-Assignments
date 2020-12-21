using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignupWithLogin.Controllers
{
    public class HomeController : Controller
    {
        private static log4net.ILog Log { get; set; }
        ILog log = log4net.LogManager.GetLogger(typeof(HomeController));


        // GET: Home
        public ActionResult Index()
        {
            log.Debug("Debug message");
            log.Warn("Warn message");
            log.Error("Error message");
            log.Fatal("Fatal message");
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}