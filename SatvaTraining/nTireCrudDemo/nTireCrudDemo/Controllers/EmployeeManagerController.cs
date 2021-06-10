using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using BE;
using BL.Manager;
using BL.Manager.Interface;
using System.IO;
using Data.Model;
using System.Net.Mail;
using RestSharp;
using System.Net;
using Twilio.Clients;
using Twilio.AspNet.Mvc;
using System.Configuration;
using nTireCrudDemo.Models;
namespace nTireCrudDemo.Controllers
{
    public class EmployeeManagerController : Controller
    {
        isLogin Userlogin = new isLogin();
        SMS message = new SMS();
        Password password = new Password();
        EmployeeManagementEntities db = new EmployeeManagementEntities();
        IAppHelperManager appHelper;
        IEmployeeManager objEmployee;
        IDepartmentManager department;
        public EmployeeManagerController(IAppHelperManager manager, IEmployeeManager emp, IDepartmentManager departmentManager)
        {
            appHelper = manager;
            objEmployee = emp;
            department = departmentManager;

        }
        // GET: EmployeeManager
        public ActionResult Index()
        {
            if (Userlogin.IsUserLogin())
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult AddEmployee()
        {
            if (Userlogin.IsUserLogin())
            {
                ViewBag.list = new SelectList("");
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            try
            {
                SaveImage(employee);
                SaveResume(employee);
                bool IsAdded = Add(employee);
                if (IsAdded == false)
                {
                    TempData["msg"] = "Employee already exists!";
                    return RedirectToAction("AddEmployee");
                }
                else
                {
                    SendConfirmationByMail(employee.Email);
                    TempData["msg"] = "Employee Added Success!";
                    return RedirectToAction("EmployeeList");
                }

            }
            catch (Exception ex)
            {
                return RedirectToAction("AddEmployee");
            }

        }

        private bool Add(Employee employee)
        {
            tblEmployee objEmp = new tblEmployee();
            objEmp.AddressLine1 = employee.AddressLine1;
            objEmp.AddressLine2 = employee.AddressLine2;
            objEmp.Area = employee.Area;
            objEmp.City = employee.City;
            objEmp.Comment = employee.Comment;
            objEmp.CompanyId = SessionProxyUser.CompanyId;
            objEmp.Country = employee.Country;
            objEmp.CreatedDate = DateTime.Now;
            objEmp.DepartmentId = employee.DepartmentId;
            objEmp.Email = employee.Email;
            objEmp.FirstName = employee.FirstName;
            objEmp.IsActive = true;
            objEmp.IsContactVerify = false;
            objEmp.IsEmailVerify = false;
            objEmp.IsTrainee = employee.IsTrainee;
            objEmp.JoiningDate = Convert.ToDateTime(employee.JoiningDate).Date;
            objEmp.LastName = employee.LastName;
            objEmp.MiddleName = employee.MiddleName;
            objEmp.MobileNumber = employee.MobileNumber;
            objEmp.Password = password.Encrypt(employee.FirstName.ToLower());
            objEmp.Photo = employee.Photo;
            objEmp.PinCode = employee.Pincode;
            objEmp.Resume = employee.Resume;
            objEmp.State = employee.State;
            objEmp.TelethoneNo = employee.TelephoneNo;
            objEmp.UpdatedDate = DateTime.Now;
            bool IsAdded = objEmployee.AddEmployee(objEmp);
            return IsAdded;
        }

        private void SaveResume(Employee employee)
        {
            string filename1 = Path.GetFileNameWithoutExtension(employee.ImageFile2.FileName);
            string extension1 = Path.GetExtension(employee.ImageFile2.FileName);
            filename1 = filename1 + DateTime.Now.ToString("yymmssfff") + extension1;
            var temp1 = filename1;
            employee.Resume = filename1;
            filename1 = Path.Combine(Server.MapPath("~/Content/Resume/"), filename1);
            employee.ImageFile2.SaveAs(filename1);
        }

        private void SaveImage(Employee employee)
        {
            string filename = Path.GetFileNameWithoutExtension(employee.ImageFile.FileName);
            string extension = Path.GetExtension(employee.ImageFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            var temp = filename;
            employee.Photo = filename;
            filename = Path.Combine(Server.MapPath("~/Content/Photo/"), filename);
            employee.ImageFile.SaveAs(filename);
        }

        public ActionResult EmployeeList()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public JsonResult GetAllEmployee()
        {
            var data = objEmployee.GetEmployees().ToList();
            return Json(objEmployee.GetEmployees().ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult FilterEmployee(string Choice, string Query)
        {
            try
            {
                var data = objEmployee.GetEmployees();
                switch (Convert.ToInt32(Choice))
                {
                    case 1:
                        data = null;
                        data = objEmployee.GetEmployees().Where(m => m.Id == Convert.ToInt32(Query)).ToList();
                        break;
                    case 2:
                        data = null;
                        data = objEmployee.GetEmployees().Where(m => m.FirstName.ToLower().Contains(Query.ToLower()) || m.MiddleName.ToLower().Contains(Query.ToLower()) || m.LastName.ToLower().Contains(Query.ToLower())).ToList();
                        break;
                    case 3:
                        data = null;
                        data = objEmployee.GetEmployees().Where(m => m.Email.ToLower().Contains(Query.ToLower())).ToList();
                        break;
                    case 4:
                        data = null;
                        data = objEmployee.GetEmployees().Where(m => m.Cityname.ToLower().Contains(Query.ToLower())).ToList();
                        break;
                    case 5:
                        data = null;
                        data = objEmployee.GetEmployees().Where(m => m.Statename.ToLower().Contains(Query.ToLower())).ToList();
                        break;
                    case 6:
                        data = null;
                        data = objEmployee.GetEmployees().Where(m => m.Countryname.ToLower().Contains(Query.ToLower())).ToList();
                        break;
                    default:
                        data = objEmployee.GetEmployees().Where(m => m.FirstName.ToLower().Contains(Query.ToLower()) || m.MiddleName.ToLower().Contains(Query.ToLower()) || m.LastName.ToLower().Contains(Query.ToLower()) || m.Email.ToLower().Contains(Query.ToLower()) || m.Cityname.ToLower().Contains(Query.ToLower()) || m.Statename.ToLower().Contains(Query.ToLower()) || m.Countryname.ToLower().Contains(Query.ToLower())).ToList();
                        break;
                }
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public JsonResult ResendEmail()
        {
            var data = db.tblEmployees.Where(m => m.Id == SessionProxyUser.UserID).FirstOrDefault();
            string email = data.Email;
            SendConfirmationByMail(email);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SendOTP()
        {
            var data = db.tblEmployees.Where(m => m.Id == SessionProxyUser.UserID).FirstOrDefault();
            string MobileNumber = data.MobileNumber;
            Random r = new Random();
            string OTP = r.Next(100000, 999999).ToString();

            //Send message
            //var twilioRestClient = new TwilioRestClient(
            //        ConfigurationManager.AppSettings.Get("Twilio:AccoundSid"),
            //        ConfigurationManager.AppSettings.Get("Twilio:AuthToken"));

            //twilioRestClient.SendSmsMessage("+19722001298",MobileNumber,string.Format("Your ASP.NET MVC 4 with Twilio " +"registration verification code is: {0}", OTP));
            string Confirmation  = message.Send(MobileNumber, OTP);
            Session["OTP"] = OTP;

            return Json(Confirmation, JsonRequestBehavior.AllowGet);
        }
        public JsonResult VerifyOTP(string values)
        {
            string otpValue = values.Replace(",","").ToString();
            if (Session["OTP"].ToString() == otpValue)
            {
                int id = SessionProxyUser.UserID;
                bool Success = appHelper.VerifyMobileNumber(id);
                if (Success == true)
                {
                    return Json("Success", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Failure", JsonRequestBehavior.AllowGet);
                }
                
            }
            else
            {
                return Json("Failure", JsonRequestBehavior.AllowGet);
            }
        }
        public void SendConfirmationByMail(string email)
        {
       
            string FilePath = "E:\\Manit\\SatvaTraining\\nTireCrudDemo\\nTireCrudDemo\\Content\\Email\\Email.html";
            StreamReader str = new StreamReader(FilePath);
            string MailText = str.ReadToEnd();
            string ActivationUrl = "";
            ActivationUrl = "https://localhost:44331/EmployeeManager/SetPassword?Token=" + email;
            DateTime time = DateTime.Now;
            //var link = "<a href = '" + string.Format("{0}://{1}/EmployeeManager/ConfirmEmail/{2}", Request.Url.Scheme, Request.Url.Authority, email) + "'>Click here to activate your account.</a>";
            MailText = MailText.Replace("{UserName}", email);
            MailText = MailText.Replace("{Link}", ActivationUrl);
            MailText = MailText.Replace("{Company Name}", "Havmore");
            str.Close();

            MailMessage mail = new MailMessage();
            mail.To.Add(email);
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
        }
        public ActionResult SetPassword(string Token)
        {
            if (Token == "")
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                ViewBag.email = Token;
                return View();
            }

        }
        [HttpPost]
        public ActionResult SetPassword(string Email, string Password)
        {
            try
            {

                if ((Email == "" && Password == "") || (Email == "" || Password == ""))
                {
                    return View();
                }
                else
                {
                    bool Saved = ConfirmEmail(Email, Password);
                    if (Saved)
                    {
                        TempData["msg"] = "Email Verification Success";
                        return RedirectToAction("Login", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Login", "Home");
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool ConfirmEmail(string Email, string Password)
        {
            try
            {
                tblEmployee data = db.tblEmployees.Where(m => m.Email == Email).FirstOrDefault();
                data.Password = password.Encrypt(Password);
                data.IsEmailVerify = true;
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                int Saved = db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public ActionResult Logout()
        {
            SessionProxyUser.IsUserLogin = false;
            return RedirectToAction("Login", "Home");
        }
        #region Json
        public JsonResult GetCountry()
        {
            return Json(appHelper.GetCountries(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetState(string Countryid)
        {
            return Json(appHelper.GetStateByCountry(Convert.ToInt32(Countryid)), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCity(string Stateid)
        {
            return Json(appHelper.GetCityByState(Convert.ToInt32(Stateid)), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDepartment()
        {
            return Json(department.GetDepartments(), JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}