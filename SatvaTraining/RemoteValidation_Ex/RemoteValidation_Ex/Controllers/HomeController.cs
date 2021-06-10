using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RemoteValidation_Ex.Models;
namespace RemoteValidation_Ex.Controllers
{
    public class HomeController : Controller
    {
        ManitEmployeeManagementEntities db = new ManitEmployeeManagementEntities();
        private string password;
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult IsDepartmentAvailable(string DepartmentName)
        {
            bool available = !db.tblDepartments.Any(m => m.DepartmentName == DepartmentName);
            return Json(available, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPassword(string Password)
        {
            password = Password;
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public JsonResult IsPasswordSame(string RePassword)
        {
            bool same = false;
            if (password == RePassword)
            {
                same = true;
            }
            return Json(same, JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Department department)
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}