using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoredProcedureDemo.Models;
using PagedList;
using StoredProcedureDemo.AuthData;
namespace StoredProcedureDemo.Controllers
{
    [HandleError]
    public class CompanyController : Controller
    {
        ManitEmployeeManagementEntities db = new ManitEmployeeManagementEntities();
        // GET: Company
       
        public ActionResult Index(int? page,string sortOrder,string search)
        {
            ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";
            ViewBag.EmailSortParm = sortOrder == "Email" ? "email_desc" : "Email";
            ViewBag.ContactNoSortParm = sortOrder == "ContactNo" ? "c_desc" : "Contact";
            ViewBag.DateSortParm = sortOrder == "CreatedDate" ? "date_desc" : "Date";
            var Company = db.CompanyList().ToList().OrderBy(m => m.Id);
            switch (sortOrder)
            {
                case "id_desc":
                    Company = db.CompanyList().ToList().OrderByDescending(m => m.Id);
                    break;
                case "Name":
                    Company = db.CompanyList().ToList().OrderBy(m => m.CompanyName);
                    break;
                case "name_desc":
                    Company = db.CompanyList().ToList().OrderByDescending(m => m.CompanyName);
                    break;
                case "Email":
                    Company = db.CompanyList().ToList().OrderBy(m => m.Email);
                    break;
                case "email_desc":
                    Company = db.CompanyList().ToList().OrderByDescending(m => m.Email);
                    break;
                case "c_desc":
                    Company = db.CompanyList().ToList().OrderByDescending(m => m.ContactNo);
                    break;
                case "Contact":
                    Company = db.CompanyList().ToList().OrderBy(m => m.ContactNo);
                    break;
                case "Date":
                    Company = db.CompanyList().ToList().OrderBy(m => m.CreatedDate);
                    break;
                case "date_desc":
                    Company = db.CompanyList().ToList().OrderByDescending(m => m.CreatedDate);
                    break;
                default:
                    Company = db.CompanyList().ToList().OrderBy(m => m.Id);
                    break;
            }
            List<tblCompany> objCompany = new List<tblCompany>();
            foreach (var item in Company)
            {
                tblCompany c = new tblCompany();
                c.Id = item.Id;
                c.IsActive = item.IsActive;
                c.Password = item.Password;
                c.CompanyName = item.CompanyName;
                c.ContactNo = item.ContactNo;
                c.CreatedDate = item.CreatedDate;
                c.Email = item.Email;
                objCompany.Add(c);
                c = null;
            }
            if (!String.IsNullOrEmpty(search))
            {
                objCompany = objCompany.Where(s => s.CompanyName.Contains(search) ||
                                                s.ContactNo.Contains(search) ||
                                                s.Email.Contains(search)
                                                ).ToList();
            }
           
           
            var data = objCompany;
            int pageSixe = 2;
            int pageNumber = (page ?? 1);
            return View(objCompany.ToPagedList(pageNumber,pageSixe));
        }
      
        
        public ActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult Create(tblCompany company)
        {
            try
            {
                company.IsActive = true;
                var msg = db.AddCompany(company.CompanyName, company.Email, company.Password, company.ContactNo, company.IsActive);
                if (msg==1)
                {
                    TempData["color"] = "text-primary";
                    TempData["msg"] = "Success.....!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["color"] = "text-danger";
                    TempData["msg"] = "Data already exists!";
                    return RedirectToAction("Create");
                }
                
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.InnerException.ToString());
            }
        }
        public ActionResult Edit(int? id)
        {
            try
            {
                var company = db.GetCompany(id).FirstOrDefault();
                tblCompany com = new tblCompany();
                com.CompanyName = company.CompanyName;
                com.Password = company.Password;
                com.ContactNo = company.ContactNo;
                com.CreatedDate = company.CreatedDate;
                com.Email = company.Email;
                com.Id = company.Id;
                com.IsActive = company.IsActive;
                com.Password = company.Password;
                return View(com);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Edit(tblCompany company)
        {
            try
            {
                var msg = db.EditCompany(company.Id, company.CompanyName, company.Email, company.Password, company.ContactNo,company.IsActive);
                string success = msg.ToString();
               
                    TempData["color"] = "text-primary";
                    TempData["msg"] = "Success.....!";
               
                
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                var msg = db.DeleteCompany(id);
                TempData["color"] = "text-primary";
                TempData["msg"] = "Success.....!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}