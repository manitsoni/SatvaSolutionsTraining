using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using BL.Manager;
using BL.Manager.Interface;
using Common;
using Data.Model;

namespace nTireCrudDemo.Controllers
{
    public class HomeController : Controller
    {
        private ICompanyManager company;
        isLogin UserLogin = new isLogin();
        IsEmployeeVerified Verified = new IsEmployeeVerified();
        EmployeeManagementEntities db = new EmployeeManagementEntities();
        public HomeController(ICompanyManager manager)
        {
            company = manager;
        }
        public ActionResult Index()
        {
            if (UserLogin.IsUserLogin())
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
            
        }
        public ActionResult OTPVerify()
        
        {
            if (Verified.Verified())
            {
                return RedirectToAction("Index", "EmployeeDashboard");
            }
            else
            {
                EmployeeManagementEntities db = new EmployeeManagementEntities();
                var data = db.tblEmployees.Where(m => m.Id == SessionProxyUser.UserID).FirstOrDefault();
                string MobileNumber = data.MobileNumber;
                ViewBag.result = MobileNumber.Substring(MobileNumber.Length - 4);
                return View();
            }
        }
       
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Email,string Password,string type)
        {
            try
            {
                SessionProxyUser.IsEmployeeVerified = false;
                SessionProxyUser.IsSuperUserLogin = false;
                SessionProxyUser.IsUserLogin = false;
                if (type == "0")
                {
                    TempData["msg"] = "Please select type";
                    return View();
                }
                else
                {
                    if (type == "1")
                    {
                        if (Email == "" || Password == "")
                        {
                            TempData["msg"] = "Enter Crendential";
                            return RedirectToAction("Login");
                        }
                        else
                        {
                            bool IsAvailable = company.Login(Email, Password);
                            if (IsAvailable)
                            {
                                return RedirectToAction("Index", "EmployeeManager");
                            }
                            else
                            {
                                TempData["msg"] = "Invalid Crendential!";
                                return RedirectToAction("Login");
                            }

                        }

                    }
                    else
                    {
                        bool IsEmployeeAvailable = company.EmployeeLogin(Email, Password);
                        if (IsEmployeeAvailable)
                        {
                            bool IsEmailVerify = company.IsEmployeeVerify(Email, Password);
                            if (IsEmailVerify)
                            {
                                return RedirectToAction("About");
                            }
                            else
                            {
                                bool IsOTPVerify = company.IsOTPVerify(Email, Password);
                                if (IsOTPVerify)
                                {
                                    return RedirectToAction("OTPVerify");
                                }
                                else
                                {
                                    SessionProxyUser.IsEmployeeVerified = true;
                                    return RedirectToAction("Index", "EmployeeDashboard");
                                }                             
                            }
                        }
                        else
                        {
                            TempData["msg"] = "Invalid Crendential!";
                            return RedirectToAction("Login");
                        }
                    }
                  
                }    
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
                return RedirectToAction("Login");
            }
           
        }
        [HttpPost]
        public ActionResult SuperLogin(string Email,string Password)
        {
            if (Email == "manitsoni369@gmail.com" && Password == "123456")
            {
                SessionProxyUser.IsSuperUserLogin = true;
                return RedirectToAction("Index","SuperAdmin");
            }
            else
            {
                TempData["msg"] = "Invalid Crendential!";
                return RedirectToAction("Login");
            }
        }
        public JsonResult Email(string Email)
        {
            return Json(SendEmail(Email), JsonRequestBehavior.AllowGet);
        }
        public bool SendEmail(string Email)
        {
            var name = db.tblEmployees.Where(m => m.Email == Email).FirstOrDefault();
            var cname = db.tblCompanies.Where(m => m.Id == name.CompanyId).FirstOrDefault();
            string FilePath = "E:\\Manit\\SatvaTraining\\nTireCrudDemo\\nTireCrudDemo\\Content\\Email\\ChangePasswordEmail.html";
            StreamReader str = new StreamReader(FilePath);
            string MailText = str.ReadToEnd();
            string ActivationUrl = "";
            ActivationUrl = "https://localhost:44331/EmployeeManager/SetPassword?Token=" + Email;
            DateTime time = DateTime.Now;
            //var link = "<a href = '" + string.Format("{0}://{1}/EmployeeManager/ConfirmEmail/{2}", Request.Url.Scheme, Request.Url.Authority, email) + "'>Click here to activate your account.</a>";
            MailText = MailText.Replace("{Name}", name.FirstName +" "+ name.MiddleName+" "+name.LastName);
            MailText = MailText.Replace("{Link}", ActivationUrl);
            MailText = MailText.Replace("{Company Name}", cname.CompanyName);
            str.Close();

            MailMessage mail = new MailMessage();
            mail.To.Add(Email);
            mail.From = new MailAddress("cargoviohub@gmail.com");
            mail.Subject = "Account Created";
            string Body = MailText;
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("cargoviohub@gmail.com", "Password@123");
            smtp.EnableSsl = true;
            smtp.Send(mail);
            return true;
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}