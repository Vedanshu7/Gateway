using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SourceControl.Models
{
    public class Login
    {
        [Required]
        [StringLength(100)]
        [Display(Description = "Email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }


        [Required]
        [StringLength(100)]
        [Display(Description = "Password")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,15}$", ErrorMessage = "Password only Contain Upper Case ,Lower case, Number and special Character")]
        public string Password { get; set; }
    }
}