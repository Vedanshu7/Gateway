using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProductModel.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Short_Description { get; set; }
        public string Long_Description { get; set; }
        public string Small_Image { get; set; }

        public string Large_Image { get; set; }
    }
}
