using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Automapper_Ex.Models;
namespace Automapper_Ex.Controllers
{
    public class HomeController : Controller
    {
        ManitEmployeeManagementEntities db = new ManitEmployeeManagementEntities();
        [Route("home")]
        public ActionResult Index()
        {
            Company listCompany = AutoMapper.Mapper.Map<Company>(db.tblCompanies.FirstOrDefault());

            Company company = new Company();
            company.CompanyName = "HINIT JEWELS";
            company.ContactNo = "9737912023";
            company.Email = "HINITJEWELS@gmail.com";
            company.IsActive = true;
            company.Password = "HINIT";

            tblCompany companyData = AutoMapper.Mapper.Map<tblCompany>(company);
            db.tblCompanies.Add(companyData);
            db.SaveChanges();
            return View(listCompany);
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