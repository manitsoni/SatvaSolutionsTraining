using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace BE
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Firstname is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Middlename is required")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Lastname is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Addressline1 is required")]
        public string AddressLine1 { get; set; }

        [Required(ErrorMessage = "Addressline2 is required")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Area is required")]
        public string Area { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public int? Country { get; set; }

        [Required(ErrorMessage = "State is required")]
        public int? State { get; set; }

        [Required(ErrorMessage = "City is required")]
        public int? City { get; set; }

        [Required(ErrorMessage ="Pincode is required")]
        
        public string Pincode { get; set; }

        [Required(ErrorMessage = "Telephoneno is required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string TelephoneNo { get; set; }

        [Required(ErrorMessage = "Mobilenumber is required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Joiningdate is required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime JoiningDate { get; set; }


        [Required(ErrorMessage ="Department is required")]
        public int? DepartmentId { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
       

        [Required(ErrorMessage = "Comment is required")]
        public string Comment { get; set; }
      

        [Required(ErrorMessage = "Please select file.")]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.jgeg|.jpg|.)$", ErrorMessage = "Only Image files allowed.")]
        public HttpPostedFileBase ImageFile { get; set; }


        [Required(ErrorMessage = "Please select file.")]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.pdf|.docx)$", ErrorMessage = "Only Docx/PDF files allowed.")]
        public HttpPostedFileBase ImageFile2 { get; set; }

        public bool IsTrainee { get; set; }
        public int? CompanyId { get; set; }
        public string Resume { get; set; }
        public string Photo { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool? IsEmailVerify { get; set; }
        public bool? IsContactVerify { get; set; }
        public bool? IsActive { get; set; }
    }
}