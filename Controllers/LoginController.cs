using SignupWithLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignupWithLogin.Controllers
{
    public class LoginController : Controller
    {
        SignupLoginEntities db = new SignupLoginEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(user u)
        {
            var user = db.users.Where(model => model.Username == u.Username && model.Password == u.Password).FirstOrDefault();
            if(user != null)
            {
                Session["UserId"] = u.Id.ToString();
                Session["Username"] = u.Username.ToString();
                Session["FirstName"+"LastName"] = u.Username.ToString();
                Session["Email"] = u.Username.ToString();
                TempData["LoginSuccessMesage"] = "<script>alert('Login Successfull!!</script>";
                return RedirectToAction("Index", "User");
            }
            else
            {
                ViewBag.ErrorMessage = "<script>alert('Username or password is invalid!!</script>";
                return View();

            }
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(user u, HttpPostedFileBase file)
        {
            if(ModelState.IsValid == true)
            {
                db.users.Add(u);
                int a = db.SaveChanges();
                if(a > 0)
                {
                    ViewBag.InsertMessage = "<script>alert('Registered Successfully!!</script>";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Registered Failed!!</script>";

                }

            }
            return View();
        }

    }
}