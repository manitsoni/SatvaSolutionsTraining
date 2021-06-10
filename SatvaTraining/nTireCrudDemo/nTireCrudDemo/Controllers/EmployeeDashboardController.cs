using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using Data.Model;
using BL.Manager;
using BL.Manager.Interface;
namespace nTireCrudDemo.Controllers
{
    public class EmployeeDashboardController : Controller
    {
        // GET: EmployeeDashboard
        IsEmployeeVerified EmployeeVerify = new IsEmployeeVerified();
        IEmployeeManager manager;
        public EmployeeDashboardController(IEmployeeManager employee)
        {
            manager = employee;
        }
        public ActionResult Index()
        {
            if (EmployeeVerify.Verified())
            {
               
                
                return View();
            }
            else
            {
                TempData["Message"] = "Please verify otp.";
                return RedirectToAction("OTPVerify", "Home");
            }
            
        }
        public ActionResult GetMyInfo()
        {
            if (EmployeeVerify.Verified())
            {
                ViewBag.list = new SelectList("");
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        [HttpPost]
        public ActionResult GetMyInfo(tblEmployee employee)
        {
            return RedirectToAction("GetMyInfo");
        }
        public JsonResult GetInfo()
        {
            return Json(manager.GetMyInfo().ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}