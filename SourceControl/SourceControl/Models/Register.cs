using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using SourceControl.Models.CustomValidation;

namespace SourceControl.Models
{
    public class Register 
    {
     

        [Required]
        [StringLength(100)]
        [Display(Description = "First Name")]
        [RegularExpression("([a-zA-Z]+)", ErrorMessage = "Enter only alphabets for First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Description = "Last Name")]
        [RegularExpression("([a-zA-Z]+)", ErrorMessage = "Enter only alphabets for First Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Description = "Email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }


        [Required]
        [StringLength(100)]
        [Display(Description = "Password")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,15}$", ErrorMessage = "Password must Contain Upper Case ,Lower case, Number and special Character")]
        public string Password { get; set; }



        [NotMapped]
        [Required]
        [StringLength(100)]
        [Display(Description = "ConfirmPassword")]
        [Compare("Password",ErrorMessage ="Password is not matched")]
        public string ConfirmPassword { get; set; }


        [Required]
        [Display(Description = "PhoneNumber")]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Invalid phone number must be length of 10")]
        public string PhoneNumber { get; set; }


        [Display(Description = "Age")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [CustomValidationAttributeForAge]
        public DateTime Age { get; set; }


    }
}