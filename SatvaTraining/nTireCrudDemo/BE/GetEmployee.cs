using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class GetEmployee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Area { get; set; }
        public int? Country { get; set; }
        public int? State { get; set; }
        public int? City { get; set; }
        public string Countryname { get; set; }
        public string Statename { get; set; }
        public string Cityname { get; set; }
        public string TelephoneNo { get; set; }
        public string MobileNumber { get; set; }
        public string JoiningDate { get; set; }
        public bool? IsTrainee { get; set; }
        public int? CompanyId { get; set; }
        public int? DepartmentId { get; set; }
        public string Companyname { get; set; }
        public string Departmentname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Pincode { get; set; }
        public string Comment { get; set; }
        public string Resume { get; set; }
        public string Photo { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public bool? IsEmailVerify { get; set; }
        public bool? IsContactVerify { get; set; }
        public bool? IsActive { get; set; }
       
    }
}
