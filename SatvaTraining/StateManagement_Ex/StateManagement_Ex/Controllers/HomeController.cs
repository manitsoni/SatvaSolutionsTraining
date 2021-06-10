using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateManagement_Ex.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var data = "Manit";
            TempData["name"] = data;
            Response.Cookies.Add(new HttpCookie("Name", data));
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            HttpCookie ck = new HttpCookie("Name");
            ck.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(ck);
            return View();
        }

        public ActionResult Contact()
        {
          
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}