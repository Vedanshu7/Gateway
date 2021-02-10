using System;
using System.Collections.Generic;
using System.Text;

namespace DriverEntities.Entities
{
    public class Car
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int TotalSeats { get; set; }
        public int DriverId { get; set; }
        public DateTime AvailabilityDateTimeFrom { get; set; }
        public DateTime AvailabilityDateTimeTo { get; set; }
        public int TotalTripKM { get; set; }
        public int RatePerKM { get; set; }
        public string CurrentLocation { get; set; }
        public string DestinationLocation { get; set; }

    }
}
