using SBS.Common.CommonModels;
using SBS.DAL.Database;
using SBS.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly Database.SBSEntities _db;
        public AuthenticationRepository()
        {
            _db = new Database.SBSEntities();
        }
        public LoginResult Login(Customer login)
        {
            LoginResult result = new LoginResult();
            if (login != null)
            {
                var customer = _db.Customers.Where(c => c.Email.Equals(login.Email)).FirstOrDefault();
                if (customer != null)
                {
                    if (login.Password.Equals(customer.Password))
                    {
                        result.loginuserid = customer.Id;
                        result.attempt = true;
                        return result;
                    }
                }
            }
            result.attempt = false;
            return result;
        }

        public bool Register(Customer register, Vehicle vehicle)
        {
            if (register != null)
            {
                register.CreatedDate = DateTime.Now;
                register.IsActive = true;
                _db.Customers.Add(register);
                _db.SaveChanges();
               
                //if (vehicle != null)
                //{
                //    var id = _db.Customers.Where(c => c.Email.Equals(register.Email)).FirstOrDefault().Id;
                //    vehicle.Cust_Id = id;
                //    _db.Vehicles.Add(vehicle);
                //    _db.SaveChanges();
                //}

                return true;
            }
            return false;
        }
    }
}
