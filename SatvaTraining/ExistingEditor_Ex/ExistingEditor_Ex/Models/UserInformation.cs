using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExistingEditor_Ex.Models
{
    public class UserInformation
    {
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Gender is required!")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Education is required!")]
        public education Education { get; set; }
        [Required(ErrorMessage = "Hobbies is required!")]
        public hobbies Hobbies { get; set; }
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Date is required!")]
        public string Date { get; set; }
        public enum education
        {
            SSC,
            HSC,
            BCOM,
            BCA,
            BBA
        }
        public enum hobbies
        {
            Cricket,
            Vollyball,
            Hokcey,
            Singing,
            WebDevelopments,
            WebDesigning
        }
    }
}