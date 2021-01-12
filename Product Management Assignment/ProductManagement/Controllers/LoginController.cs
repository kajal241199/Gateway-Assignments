using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;
using ProductManagement.Models;

namespace ProductManagement.Controllers
{
   public class LoginController : Controller
   {
        private static Logger logger = LogManager.GetLogger("MyAppLoggerRules");
        LoginDBEntities db = new LoginDBEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //Method for login into the system
        [HttpPost]
        public ActionResult Index(Login s)
        {

            logger.Info("Entering the Login controller. Index Method");
            try
            {
                if (ModelState.IsValid == true)
                {
                    var credentials = db.Logins.Where(model => model.Email_ID == s.Email_ID && model.Password == s.Password).FirstOrDefault();
                    if (credentials == null)
                    {
                        ViewBag.ErrorMessage = "Email ID or Password is invalid";
                        logger.Info("Exit Login COntroller .Login failure!");
                        return View();
                    }
                    else
                    {
                        Session["Email_ID"] = s.Email_ID;
                        logger.Info("Exit Login COntroller .Login success!");
                        return RedirectToAction("Index", "Home1");
                    }
                }
                return View();

            }
            catch(Exception e)
            {
                logger.Error("Exception!" + e.Message);
                return Content("Exception in login" + e.Message);

            }
            
        }

        //Logout Method
        public ActionResult Logout()
        {
            logger.Info("Entering the Login controller. Index Method");
            try
            {
                Session.Abandon();
                logger.Info("Logout successfully!");
                return RedirectToAction("Index", "Login");
            }
            catch (Exception e)
            {
                logger.Error("Exception!" + e.Message);
                return Content("Exception in logout" + e.Message);

            }
        }

        //To reset the details entered by the user
        public ActionResult Reset()
        {
            //clear the entered details
            ModelState.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}