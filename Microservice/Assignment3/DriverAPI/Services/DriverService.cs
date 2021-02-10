using DriverEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriverAPI.Services
{
    public class DriverService
    {
        public List<Driver> GetDrivers()
        {
            var drivers = new List<Driver>()
            {
                new Driver(){Id=1,Address="DUmmy",Email="xyz@.com",MobileNumber="12345",Name="testdriver",PaymentId=1 },
                 new Driver(){Id=2,Address="DUmmy1",Email="xyzs@.com",MobileNumber="1234546",Name="testdriver1",PaymentId=2 }
            };
            return drivers;
        }
    }
}
