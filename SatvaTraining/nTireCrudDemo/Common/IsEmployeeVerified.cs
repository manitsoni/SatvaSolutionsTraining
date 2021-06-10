using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class IsEmployeeVerified
    {
        public bool Verified()
        {
            var _Result = SessionProxyUser.IsEmployeeVerified;
            if (_Result == true)
            {
                return true;
            }
            return false;
        }
    }
}
