using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentEntities.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int TotalAmount { get; set; }
        public DateTime Datetime { get; set; }
        public string PaymentMethod { get; set; }

    }
}
