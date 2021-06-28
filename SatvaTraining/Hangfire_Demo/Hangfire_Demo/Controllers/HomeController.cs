using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Hangfire_Demo.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            TwilioClient.Init("AC5f1138b584d0970b092536d295df44ae", "54b4a039a1f055ec850a2555eee442b4");
            var message = MessageResource.Create(
                body: "Join Earth's mightiest heroes. Like Kevin Bacon.",
                from: new Twilio.Types.PhoneNumber("+919624103001"),
                to: new Twilio.Types.PhoneNumber("+919737920098")
            );
        }
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
        public async Task<ActionResult> EmailSend()
        {
            
            Send();
            //SendSMS();
            return Json(0, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> SMSSend()
        {     
            SendWP();
            return Json(0, JsonRequestBehavior.AllowGet);
        }
        public async static Task Send()
        {
            try
            {
               
                var senderEmail = "cargoviohub@gmail.com";
                var senderPassword = "Password@123";
                var displayName = "Test Email";

                var receiverEmail = "manitsoni369@gmail.com";

                MailMessage myMessage = new MailMessage();
                myMessage.To.Add(receiverEmail);
                myMessage.From = new MailAddress(senderEmail, senderPassword);
                myMessage.Subject = "Test Email";
                myMessage.Body = "Test Message Success";
                myMessage.IsBodyHtml = true;

                using(SmtpClient smtp = new SmtpClient())
                {
                    smtp.EnableSsl = true;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.SendCompleted += (s, e) => { smtp.Dispose(); };
                    await smtp.SendMailAsync(myMessage);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //public async static Task SendSMS()
        //{
        //    string key = "6uq3x8r93yh73qs";
        //    string secret = "321";
        //    string to = "919737920098";
        //    string messages = "Hello manit " + DateTime.Now.ToString();

        //    string sURL;


        //    sURL = "https://www.thetexting.com/rest/sms/json/message/send?api_key=" + key + "&api_secret=" + secret + "&to=" + to + "&text=" + messages;
        //    using (WebClient client = new WebClient())
        //    {

        //        string s = client.DownloadString(sURL);

        //        var responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject(s);
        //        string n = responseObject.ToString();
        //    }
        //}
        public async static Task SendWP()
        {
            var message = MessageResource.Create(
                from: new Twilio.Types.PhoneNumber("whatsapp:+14155238886"),
                body: "Hello, there!",
                to: new Twilio.Types.PhoneNumber("whatsapp:+919737920098")
            );
        }
      
    }
}