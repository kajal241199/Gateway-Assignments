using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagement.Controllers
{
    public class Home1Controller : Controller
    {
        
        // GET: Home1
        public ActionResult Index()
        {
                //Check if Email is null or not
                if (Session["Email_Id"] == null)
                {
                    
                    return RedirectToAction("Index", "Login");
                }
                return View();

        
            
        }
    }
}