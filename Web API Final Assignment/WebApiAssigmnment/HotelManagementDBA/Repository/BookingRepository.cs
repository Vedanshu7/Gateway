using HotelManagementDBA.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementDBA.Repository
{
    public class BookingRepository:IBookingRepository
    {
        private readonly HotelManagementDBA.Database.HotelManagmentEntities _db;

        public BookingRepository()
        {
            _db = new Database.HotelManagmentEntities();
        }
        public int Delete_Booking(int booking_id)
        {
            if (!booking_id.Equals(null))
            {
                Database.Booking booking = _db.Bookings.Find(booking_id);
                booking.Status = "Deleted";
                _db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
            
        }

        public int Update_Booking(int room_id, DateTime date,string status)
        {
            if (status == "")
            {
                if(!room_id.Equals(null) && !date.Equals(null))
                {
                    Database.Booking booking = _db.Bookings.Where(i => i.Room_Id == room_id).FirstOrDefault();
                    booking.Booking_Date = date;
                    _db.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
               
            }
            else
            {
                if (!room_id.Equals(null) && !date.Equals(null))
                {
                    Database.Booking booking = _db.Bookings.Where(i => i.Room_Id == room_id && i.Booking_Date == date).FirstOrDefault();
                    booking.Status = status;
                    _db.SaveChanges();
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

    }
}
