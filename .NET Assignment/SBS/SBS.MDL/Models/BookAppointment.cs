using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.MDL.Models
{
    public class BookAppointment
    {
        public int Id { get; set; }
        public int DealerId { get; set; }
        public string DealerName { get; set; }
        public int VehicleId { get; set; }
        public string VehicleModel { get;set; }
        public int MechanicId { get; set; }
        public string MechanicName { get; set; }
        public int ServiceId { get; set; }
        public string ServiceType { get; set; }
        public int CustomerId { get; set; }
        public System.DateTime BookingDateTime { get; set; }
    }
}
