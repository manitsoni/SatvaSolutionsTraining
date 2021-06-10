using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PartialViewDemo.Models;
namespace PartialViewDemo.Controllers
{
    public class HomeController : Controller
    {
        EmployeeManagementEntities db = new EmployeeManagementEntities();
        public ActionResult Index()
        {
            return View(db.tblCompanies.ToList());
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