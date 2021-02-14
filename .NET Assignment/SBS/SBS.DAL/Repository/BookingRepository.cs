using SBS.DAL.Database;
using SBS.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly Database.SBSEntities _db;
        public BookingRepository()
        {
            _db = new Database.SBSEntities();
        }
        public bool Booking(Appointment appointment)
        {
            appointment.CreatedDate = DateTime.Now;
            appointment.IsActive = true;
            appointment.MechanicId =_db.Mechanics.Where(m=>m.Dealer_Id==appointment.DealerId).FirstOrDefault().Id;
            _db.Appointment.Add(appointment);
            _db.SaveChanges();
            return true;
        }

        public List<Appointment> GetBookings(int customerId)
        {
            List<Appointment> appointments = _db.Appointment.Where(a => a.CustomerId == customerId).ToList();
            return appointments;
        }
    }
}
