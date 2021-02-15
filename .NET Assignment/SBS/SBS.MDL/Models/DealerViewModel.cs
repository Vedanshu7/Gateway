using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.MDL.Models
{
    public class DealerViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string HomePhone { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
    }
}
