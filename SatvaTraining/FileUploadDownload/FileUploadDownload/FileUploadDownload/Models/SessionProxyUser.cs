using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FileUploadDownload
{
    public class SessionProxyUser
    {
       
     
        public const string ISUSERLOGIN = "IsUserLogin";
        public const string ProductId = "ProductId";
        public const string USEREMAIL = "UserEmail";
        private SessionProxyUser()
        {

        }

        public static SessionProxyUser Current
        {
            get
            {
                SessionProxyUser sessionProxy = (SessionProxyUser)HttpContext.Current.Session["__ApplicationSessionAdmin__"];
                if (sessionProxy == null)
                {
                    sessionProxy = new SessionProxyUser();
                    HttpContext.Current.Session["__ApplicationSessionAdmin__"] = sessionProxy;
                }
                return sessionProxy;
            }
            set { SessionProxyUser mysession = (SessionProxyUser)value; }
        }

      

       
        public static int ProductID
        {
            get
            {
                return Convert.ToInt32(HttpContext.Current.Session[ProductId]);
            }
            set
            {
                HttpContext.Current.Session[ProductId] = value;
            }
        }
        public static bool IsUserLogin
        {
            get
            {
                return Convert.ToBoolean(HttpContext.Current.Session[ISUSERLOGIN]);
            }
            set
            {
                HttpContext.Current.Session[ISUSERLOGIN] = value;
            }
        }
        public static string UserEmail
        {
            get
            {
                return Convert.ToString(HttpContext.Current.Session[USEREMAIL]);
            }
            set
            {
                HttpContext.Current.Session[USEREMAIL] = value;
            }
        }

    }
}
