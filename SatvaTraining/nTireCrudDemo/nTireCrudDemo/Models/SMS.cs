using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace nTireCrudDemo.Models
{
    public class SMS
    {
        public string Send(string ContactNo, string MessageBody)
        {
            try
            {
                string key = "62393yhhg8i6fd7";
                string secret = "hjq77bqxt5a2nrk";
                string to = "91" + ContactNo;
                string messages = MessageBody;

                string sURL;

                sURL = "https://www.thetexting.com/rest/sms/json/Message/Send?api_key=" + key + "&api_secret=" + secret + "&to=" + to + "&text=" + messages;
                //sURL = "https://www.thetexting.com/rest/sms/json/message/send?api_key=" + key + "&api_secret=" + secret + "&to=" + to + "&text=" + messages;
                using (WebClient client = new WebClient())
                {

                    string s = client.DownloadString(sURL);

                    var responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject(s);
                    string n = responseObject.ToString();
                    return "Otp Sent Successfully.....";

                }
            }
            catch (System.Net.WebException ex)
            {
                return ex.Message;
            }
          

        }

        abstract class RootObject
        {
            public WebResponse Response { get; set; }
            public string ErrorMessage { get; set; }
            public int Status { get; set; }
        }
    }
}