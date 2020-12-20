using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Assignment1.CustomValidation;

namespace Assignment1.Models
{
    public class Register
    {


        [Required]
        [StringLength(100)]
        [Display(Description = "First Name")]
        [RegularExpression("([a-zA-Z]{3,})", ErrorMessage = "Enter only alphabets for First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Description = "Last Name")]
        [RegularExpression("([a-zA-Z]{3,})", ErrorMessage = "Enter only alphabets for First Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Description = "Email")]
        [RegularExpression("^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$", ErrorMessage = "Please enter a valid email")]
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
        [Compare("Password", ErrorMessage = "Password is not matched")]
        public string ConfirmPassword { get; set; }


        [Required]
        [Display(Description = "PhoneNumber")]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Invalid phone number must be length of 10")]
        public string PhoneNumber { get; set; }


        [Display(Description = "Age")]
        [DisplayFormat(DataFormatString = "{0:mm/DD/yyyy}", ApplyFormatInEditMode = true)]
        [CustomValidationAttributeForAge]
        public DateTime Age { get; set; }

        

        [Display(Description ="Profile Picture")]
        
        public HttpPostedFileBase Image { get; set; }


        [FileExtensions(Extensions = "jpg,jpeg,png",ErrorMessage ="Only jpg,jpeg and png allowed")]
        public string image_path
        {
            get
            {
                if (Image != null)
                    return Image.FileName;
                else
                    return "";
            }
        }

        [Display(Description = "Country")]
        [Required]
        [StringLength(50)]
        public string Conntry { get; set; }

        [Display(Description ="State")]
        [RegularExpression("([a-zA-Z]{3,})", ErrorMessage = "Enter only alphabets for State")]
        [Required]
        [StringLength(50)]
        public string State { get; set; }

        [Display(Description = "City")]
        [RegularExpression("([a-zA-Z]{3,})", ErrorMessage = "Enter only alphabets for City")]
        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Display(Description = "Town")]
        [RegularExpression("([a-zA-Z]{3,})", ErrorMessage = "Enter only alphabets for Town")]
        [StringLength(50)]
        [Required]
        public string Town { get; set; }

        [Display(Description ="PinCode")]
        
        [Required]
        [StringLength(20)]
        public string Pincode { get; set; }

        [Display(Description = "Gender")]
        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

    }
}