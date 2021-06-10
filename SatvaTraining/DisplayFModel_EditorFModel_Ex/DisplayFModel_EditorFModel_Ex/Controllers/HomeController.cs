using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DisplayFModel_EditorFModel_Ex.Models;
namespace DisplayFModel_EditorFModel_Ex.Controllers
{
    public class HomeController : Controller
    {
        ManitEmployeeManagementEntities db = new ManitEmployeeManagementEntities();
        public ActionResult Index()
        {
            tblCompany company = db.tblCompanies.FirstOrDefault();
            return View(company);
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