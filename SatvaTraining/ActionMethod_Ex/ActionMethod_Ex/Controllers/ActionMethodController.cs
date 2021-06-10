using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActionMethod_Ex.Controllers
{
    public class ActionMethodController : Controller
    {
        // GET: ActionMethod
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetMyData()
        {
            return Json("{'message':hello}", JsonRequestBehavior.AllowGet);
        }
        public ContentResult GetContent()
        {
            return Content("Hello, Sir Good Afternoon");
        }
        public PartialViewResult GetPartial()
        {
            return PartialView();
        }
        public FileResult DownloadFile()
        {
            var myFile = System.IO.File.ReadAllBytes(@"E:\Manit\SatvaTraining\nTireCrudDemo\nTireCrudDemo\Content\Photo\password_incorrect210350084.png");
            return File(myFile, "application/octet-stream");
        }
    }
}