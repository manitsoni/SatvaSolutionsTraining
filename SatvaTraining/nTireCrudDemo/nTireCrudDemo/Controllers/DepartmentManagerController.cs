using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using BE;
using BL.Manager;
using BL.Manager.Interface;
namespace nTireCrudDemo.Controllers
{
    public class DepartmentManagerController : Controller
    {
        isLogin Userlogin = new isLogin();
        private IDepartmentManager departmentManager;
        public DepartmentManagerController(IDepartmentManager department)
        {
            departmentManager = department;
        }
        // GET: DepartmentManager
        public ActionResult Index()
        {
            if (Userlogin.IsUserLogin())
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
            
        }
        public JsonResult GetDepartments()
        {
            return Json(departmentManager.GetDepartments(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddDepartmenr(string Id,string DepartmentName)
        {
            if (Id == "")
            {
                Department department = new Department();
                department.CompanyId = SessionProxyUser.CompanyId;
                department.DepartmentName = DepartmentName;
                bool IsAdded = departmentManager.AddDepartment(department);
                return Json(IsAdded,JsonRequestBehavior.AllowGet);
            }
            else
            {
                Department department = new Department();
                department.Id = Convert.ToInt32(Id);
                department.CompanyId = SessionProxyUser.CompanyId;
                department.DepartmentName = DepartmentName;
                bool IsUpdated = departmentManager.EditDepartment(department);
                return Json(IsUpdated,JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetById(string Id)
        {
            return Json(departmentManager.GetDepartment(Convert.ToInt32(Id)), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(string Id)
        {
            return Json(departmentManager.DeleteDepartment(Convert.ToInt32(Id)), JsonRequestBehavior.AllowGet);
        }
    }
}