using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Routing_VR.Controllers
{
   
    public class HomeController : Controller
    {
        [Route("abc/home/index")]
        public ActionResult Index()
        {
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
        [Route("home/getbyid/{id}")]
        public ActionResult GetById(int id)
        {
            return View();
        }
    }
}