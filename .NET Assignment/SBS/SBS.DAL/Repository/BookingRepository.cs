using SBS.DAL.Database;
using SBS.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public bool DeleteBooking(int id, int customerId)
        {
            var result = _db.Appointment.Remove(_db.Appointment.Where(a => a.Id == id && a.CustomerId == customerId).FirstOrDefault());
            if (result!=null)
            {
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public Appointment GetBooking(int id, int customerId)
        {
            Appointment appointment = _db.Appointment.Where(a => a.CustomerId == customerId && a.Id == id).FirstOrDefault();
            return appointment;
        }

        public List<Appointment> GetBookingOfDealer(int dealerId)
        {
            List<Appointment> appointments = _db.Appointment.Where(a => a.DealerId == dealerId).ToList();
            return appointments;
        }

        public List<Appointment> GetBookings(int customerId)
        {
            List<Appointment> appointments = _db.Appointment.Where(a => a.CustomerId == customerId).ToList();
            return appointments;
        }

        public bool UpdateBooking(Appointment appointment)
        {
            Appointment appointmentfromdb = _db.Appointment.Where(a => a.CustomerId == appointment.CustomerId).FirstOrDefault();
            if (appointmentfromdb != null)
            {
                appointmentfromdb.BookingDateTime = appointment.BookingDateTime;
                appointmentfromdb.DealerId = appointment.DealerId;
                appointmentfromdb.ServiceId = appointment.ServiceId;
                appointmentfromdb.VehicleId = appointment.VehicleId;
                appointmentfromdb.UpdatedDate = DateTime.Now;
                _db.Entry(appointmentfromdb).State = EntityState.Modified;
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
