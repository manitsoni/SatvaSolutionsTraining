using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using FileUploadDownload.Models;
namespace FileUploadDownload.Controllers
{
    public class HomeController : Controller
    {
        FileUploadDownloadEntities db = new FileUploadDownloadEntities();
        isLogin UserLogin = new isLogin();
        public ActionResult Index()
        {
            ViewBag.data = db.tblFiles.ToList();
            return View();
        }
      
        public ActionResult AddFile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddFile(HttpPostedFileBase File)
        {
            string filename = Path.GetFileNameWithoutExtension(File.FileName);
            string extension = Path.GetExtension(File.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            var temp = filename;
            filename = Path.Combine(Server.MapPath("~/Content/Photo/"), filename);
            File.SaveAs(filename);

            tblFile fu = new tblFile();
            fu.FileName = temp;
            db.tblFiles.Add(fu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult Download(string filename)
        { 
            if (UserLogin.IsUserLogin() == false)
            {
                return RedirectToAction("Login");
            }
            else
            {
                var data = db.tblFiles.Where(m => m.FileName == filename).FirstOrDefault();
                int FId = data.Id;
                int UId = Convert.ToInt32(Session["Userid"].ToString());
                tblFileDownload fd = new tblFileDownload();
                fd.UserId = UId;
                fd.FileId = FId;
                fd.DownloadedTime = DateTime.Now;
                fd.IsActive = true;
                db.tblFileDownloads.Add(fd);
                db.SaveChanges();
                string path = Server.MapPath("~/Content/Photo/") + filename;
                byte[] bytes = System.IO.File.ReadAllBytes(path);
                return File(bytes, "application/octet-stream", filename);
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(tblRegister user)
        {
            var data = db.tblRegisters.Where(m => m.Email == user.Email).FirstOrDefault();
            if (data == null)
            {
                db.tblRegisters.Add(user);
                bool i = db.SaveChanges() > 0;
                return RedirectToAction("Login");
            }
            else
            {
                TempData["msg"] = "Email Already Exists!";
                return RedirectToAction("Register");
            }    
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Email,string Password)
        {
            try
            {
                bool IsAvailable = false;
                var data = db.tblRegisters.ToList();
                foreach (var item in data)
                {
                    if (item.Email == Email && item.Password ==  Password)
                    {
                        SessionProxyUser.IsUserLogin = true;
                        SessionProxyUser.UserEmail = item.Email;
                        Session["Userid"] = item.Id;
                        IsAvailable = true;
                        break;
                    }
                }
                if (IsAvailable)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Register");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public ActionResult Logout()
        {
            SessionProxyUser.IsUserLogin = false;
            SessionProxyUser.UserEmail = null;
            return RedirectToAction("Index");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}