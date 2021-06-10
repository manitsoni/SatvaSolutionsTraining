using BE;
using BL.Manager.Interface;
using Common;
using Data.Model;
using System;
using System.Linq;
using System.Web.Mvc;
using nTireCrudDemo.Models;
namespace nTireCrudDemo.Controllers
{
    public class SuperAdminController : Controller
    {
        private ICompanyManager companyManager;
        IsSuperUserLogin UserLogin = new IsSuperUserLogin();
        Password password = new Password();
        public SuperAdminController(ICompanyManager manager)
        {
            companyManager = manager;
        }
        // GET: SuperAdmin
        public ActionResult Index()
        {
            if (UserLogin.IsUserLogin())
            {
                TempData["msg"] = "Loaded Success";
                ViewBag.clist = new SelectList("");
                ViewBag.companylist = companyManager.GetCompanies().ToList();
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }
        public JsonResult GetData()
        {
            return Json(companyManager.GetCompanies().ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Register(string Id, string CompanyName, string Email, string Password, string Contact)
        {
            if (Id == "")
            {

                Company company = new Company();
                company.CompanyName = CompanyName;
                company.ContactNo = Contact;
                company.CreatedDate = DateTime.Now;
                company.Email = Email;
                company.Password = password.Encrypt(Password);
                company.IsActive = true;
                bool IsAdded = companyManager.Register(company);
                return Json(IsAdded, JsonRequestBehavior.AllowGet);
            }
            else
            {
                int id = Convert.ToInt32(Id);
                Company company = new Company();
                company.Id = id;
                company.CompanyName = CompanyName;
                company.ContactNo = Contact;
                company.CreatedDate = DateTime.Now;
                company.Email = Email;
                company.Password = password.Encrypt(Password);
                company.IsActive = true;
                bool IsAdded = companyManager.EditCompany(company);
                return Json(IsAdded, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult getById(string id)
        {

            var data = companyManager.GetCompany(Convert.ToInt32(id));
            tblCompany company = new tblCompany();
            company.CompanyName = data.CompanyName;
            company.ContactNo = data.ContactNo;
            company.CreatedDate = data.CreatedDate;
            company.Email = data.Email;
            company.Id = data.Id;
            company.IsActive = data.IsActive;
            company.Password = data.Password;
            return Json(company, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(string id)
        {
            return Json(companyManager.Delete(Convert.ToInt32(id)), JsonRequestBehavior.AllowGet);
        }
    }
}