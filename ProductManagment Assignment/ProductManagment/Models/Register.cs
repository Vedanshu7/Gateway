using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductManagment.Models
{
    public class Register
    {
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

    }
}