using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserEntities.Entities;

namespace UserAPI.Services
{
    public class UserService
    {
        public List<User> GetUsers()
        {
            var users = new List<User>()
            {
             new User() { Id = 1, Name="Test",Address = "Test Address 1", Email = "test@test.com", MobileNumber = "1112221112",PaymentId=1,CurrentLocation="Dummy"},
             new User() { Id = 2, Name="Test1",Address = "Test Address 2", Email = "test@test.com", MobileNumber = "1112221112",PaymentId=2,CurrentLocation="Dummy1"},
            };

            return users;
        }
    }
}
