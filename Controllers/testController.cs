using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignupWithLogin.Controllers
{
    public class testController : Controller
    {
        // GET: test
        [HandleError]
        public ActionResult Index()
        {
            throw new Exception();
        }
    }
}