using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.ViewModel;
using Core.Service;
namespace Onion_Architecture_Ex.Controllers
{
    public class HomeController : Controller
    {
        public ICompanyService service;
        public HomeController(ICompanyService s)
        {
            service = s;
        }
        public ActionResult Index()
        {
            ViewBag.Data = service.GetCompanies().ToList();
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
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CompanyViewModel viewModel)
        {
            viewModel.IsActive = true;
            viewModel.CreatedDate = DateTime.Now;
            var msg = service.AddCompany(viewModel);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            service.DeleteCompany(id);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            CompanyViewModel cVm = service.GetCompanyById(Convert.ToInt32(id)).FirstOrDefault();
            return View(cVm);
        }
        [HttpPost]
        public ActionResult Edit(CompanyViewModel cVm)
        {
            service.UpdateCompany(cVm);
            return RedirectToAction("Index");
        }
    }
}