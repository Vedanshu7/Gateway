using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementModels.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public System.DateTime Booking_Date { get; set; }
        public int Room_Id { get; set; }
        public string Status { get; set; }
    }
}
