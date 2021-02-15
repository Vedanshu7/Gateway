using SBS.DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL.Interface
{
    public interface IBookingRepository
    {
        bool Booking(Appointment appointment);
        List<Appointment> GetBookings(int customerId);
        Appointment GetBooking(int id, int customerId);
        bool UpdateBooking(Appointment appointment);
        bool DeleteBooking(int id, int customerId);
        List<Appointment> GetBookingOfDealer(int dealerId);
    }
}
