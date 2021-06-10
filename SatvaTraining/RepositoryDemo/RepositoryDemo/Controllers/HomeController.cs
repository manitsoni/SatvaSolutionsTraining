using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepositoryDemo.Repository;
namespace RepositoryDemo.Controllers
{
    public class HomeController : Controller
    {
        ICompanyRepository company = new CompanyRepository();
       
        public ActionResult Index()
        {
            var Data = company.GetCompanies().ToList();
            return View();
        }
        public PartialViewResult GetCompany()
        {
            var Data = company.GetCompanies().ToList();
            return PartialView("GetCompany");
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