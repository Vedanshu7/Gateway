using SBS.MDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BAL.Interface
{
    public interface IBookingManager
    {
        bool Booking(BookAppointment appointment);
        List<BookAppointment> GetBookings(int customerId);
    }
}
