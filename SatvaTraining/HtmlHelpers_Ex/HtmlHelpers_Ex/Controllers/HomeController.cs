using HtmlHelpers_Ex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace HtmlHelpers_Ex.Controllers
{
    public class HomeController : Controller
    {
        ManitEmployeeManagementEntities db = new ManitEmployeeManagementEntities();
        public ActionResult Index()
        {
            ViewBag.user = db.tblUserinformations.ToList();
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
        public ActionResult Create(Userinformation info,string[] Hobbies,string datetime)
        {
            tblUserinformation ui = new tblUserinformation();
            string FromDate = datetime.Substring(0, datetime.IndexOf("-"));
            string ToDate = datetime.Substring(datetime.IndexOf("-") + 1);
            
            ui.CreatedDate = DateTime.Now;
            ui.DOB = info.Date;
            ui.Education = info.Education.ToString();
            ui.Email = info.Email;
            ui.Gender = info.Gender;
            ui.IsActive = info.IsActive;
            ui.Name = info.Name;
            ui.Password = info.Password;
            ui.Hobbies = string.Join(",", Hobbies);
            db.tblUserinformations.Add(ui);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}