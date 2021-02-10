using System;
using System.Collections.Generic;
using System.Text;

namespace BookingEntities.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public int DriverId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime ExpectedEndDateTime{ get; set; }
        public int TotalRate { get; set; }
        public int TotalKM { get; set; }
        public string Pickup { get; set; }
        public string Destination { get; set; }
        public int RateScore { get; set; }
        public string Status { get; set; }

    }
}
