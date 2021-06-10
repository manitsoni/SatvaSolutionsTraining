using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class IsSuperUserLogin
    {
        public bool IsUserLogin()
        {
            var _Result = SessionProxyUser.IsSuperUserLogin;
            if (_Result == true)
            {
                return true;
            }
            return false;
        }
    }
}
