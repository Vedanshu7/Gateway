using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.MDL.Models
{
    public class BookAppointmentViewModel
    {
        public List<Dealer> DealerId { get; set; }
        public List<Vehicle> VehicleId { get; set; }
        public List<Service> ServiceId{ get; set; }
        public System.DateTime BookingDateTime { get; set; }
    }
}
