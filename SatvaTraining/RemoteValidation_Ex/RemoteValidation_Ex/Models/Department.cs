using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace RemoteValidation_Ex.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Remote("IsDepartmentAvailable","Home",ErrorMessage ="Department is already in use")]
        public string DepartmentName { get; set; }
        [Remote("GetPassword","Home")]
        public string Password { get; set; }
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string RePassword { get; set; }
        public int? CompanyId { get; set; }

    }
}