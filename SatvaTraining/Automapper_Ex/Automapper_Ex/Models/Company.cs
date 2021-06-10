using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Automapper_Ex.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ContactNo { get; set; }
        public bool IsActive { get; set; }
    }
}