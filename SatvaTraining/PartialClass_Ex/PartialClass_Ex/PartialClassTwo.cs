using System;
using System.Web;

namespace PartialClass_Ex
{
    public partial class PartialClass
    {
        private string _Firstname;
        private string _Lastname;
        public string _firstname
        {
            get { return _Firstname; }
            set { _Firstname = value;  }
        }
        public string _lastname { get => _Lastname; set => _Lastname = value; }
    }
}
