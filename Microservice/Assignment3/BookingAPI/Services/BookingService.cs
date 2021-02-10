using BookingEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Services
{
    public class BookingService
    {
        public static List<Booking> bookings = new List<Booking>();
        public bool Book(Booking booking)
        {
            bookings.Add(booking);
            return true;
        }
        public List<Booking> GetBookings()
        {
            var bookings = new List<Booking>()
            {
             new Booking() { Id = 1, CarId=1,Destination="Dest",DriverId=1,ExpectedEndDateTime=DateTime.Now,Pickup="Agra",RateScore=0,StartDateTime=DateTime.Now,Status="Accepted",TotalKM=100,TotalRate=8,UserId=1 },
             new Booking() { Id = 2, CarId=2,Destination="Dest1",DriverId=2,ExpectedEndDateTime=DateTime.Now,Pickup="Agra1",RateScore=2,StartDateTime=DateTime.Now,Status="NotAccepted",TotalKM=150,TotalRate=9,UserId=2},
            };

            return bookings;
        }
    }
}
