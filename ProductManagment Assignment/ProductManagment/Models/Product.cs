using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductManagment.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Description = "Name")]
        [RegularExpression("([a-zA-Z0-9]{3,})", ErrorMessage = "Enter only alphabets for Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Description = "Category")]
        [RegularExpression("([a-zA-Z]{3,})", ErrorMessage = "Enter only alphabets for Category")]
        public string Category { get; set; }

        [Required]
        [Display(Description = "Price")]
        public decimal Price { get; set; }

        [Required]
        [Display(Description = "Quantity")]
        public int Quantity { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Description = "Short_Description")]
        public string Short_Description { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Description = "Long_Description")]
        public string Long_Description { get; set; }

        [FileExtensions(Extensions = "jpg,jpeg,png", ErrorMessage = "Only jpg,jpeg and png allowed")]
        public string Small_Image { get; set; }

        [FileExtensions(Extensions = "jpg,jpeg,png", ErrorMessage = "Only jpg,jpeg and png allowed")]
        public string Large_Image { get; set; }


        public HttpPostedFileBase S_Image { get; set; }
        public HttpPostedFileBase L_Image { get; set; }

    }
}