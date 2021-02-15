using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.MDL.Models
{
    public class CustomerInformationViewModel
    {
        public RegisterViewModel customer { get; set; }
        public List<VehicleViewModel> vehicles { get; set; }
        public List<BookAppointment> appointments { get; set; }
    }
}
