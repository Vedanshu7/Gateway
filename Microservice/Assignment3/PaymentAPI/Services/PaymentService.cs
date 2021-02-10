using PaymentEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Services
{
    public class PaymentService
    {
        public static List<Payment> payments= new List<Payment>();
        public bool StorePayment(Payment payment)
        {
            payments.Add(payment);
            return true;
        }
        public List<Payment> GetPayments()
        {
            var payments = new List<Payment>()
            {
             new Payment() { Id = 1,BookingId=1,Datetime=DateTime.Now,PaymentMethod="UPI",TotalAmount=100},
             new Payment() { Id = 2, BookingId=2,Datetime=DateTime.Now,PaymentMethod="UPI",TotalAmount=500},
            };

            return payments;
        }
    }
}
