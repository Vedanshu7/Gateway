using HotelManagementDBA.Interface;
using HotelManagementInterface.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementInterface
{

    public class BookingManager : IBooking
    {
        private readonly IBookingRepository bookingRepository;

        
        public BookingManager(IBookingRepository _bookingRepository)
        {
            bookingRepository = _bookingRepository;
        }

        public int Delete_Booking(int booking_id)
        {
            return bookingRepository.Delete_Booking(booking_id);
        }

        public int Update_Booking(int room_id, DateTime date,string status)
        {
            return bookingRepository.Update_Booking(room_id, date,status);
        }
    }
}
