﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DriverEntities.Entities
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobileNumber { get; set; }
        public int PaymentId { get; set; }

    }
}
