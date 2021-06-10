using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoredProcedureDemo.Models;
namespace StoredProcedureDemo.Controllers
{
    public class HomeController : Controller
    {
        ManitEmployeeManagementEntities db = new ManitEmployeeManagementEntities();
        public ActionResult Index()
        {
            var data = db.CompanyList().ToList();
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
    }
}