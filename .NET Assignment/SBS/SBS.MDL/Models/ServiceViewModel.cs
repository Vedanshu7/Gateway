using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.MDL.Models
{
    public class ServiceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public System.TimeSpan Duration { get; set; }
        public bool Active { get; set; }
    }
}
