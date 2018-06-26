using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC__session_Login_.Controllers
{
    public class HomeController : Controller
    {
        SimpleBlogEntities db = new SimpleBlogEntities();
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                var list = db.Users.ToList();
                return View(list);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Login()
        {
            if (Session["user"] != null)
                return RedirectToAction("Index");
            else
                return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            bool isExist = db.Users.Any(x => x.username == user.username && x.password == user.password);

            
            if (isExist)
            {
                Session["user"] = user.username;
                return RedirectToAction("Index");
            }

            else
            {
               
              return  RedirectToAction("Login");
            }
        }
        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Login");
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