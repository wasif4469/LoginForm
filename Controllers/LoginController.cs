using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginForm.Models;

namespace LoginForm.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        StudentEntities obj = new StudentEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(user_ s)
        {
            if (ModelState.IsValid == true) 
            {
                var credentials = obj.user_.Where(model => model.username == s.username && model.pass_word == s.pass_word).FirstOrDefault();
                if (credentials == null)
                {
                    ViewBag.ErrorMessage = "Login Failed";
                    return View();

                }
                else
                {
                    Session["username"] = s.username;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}