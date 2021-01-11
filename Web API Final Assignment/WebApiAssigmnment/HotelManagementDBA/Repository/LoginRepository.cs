using HotelManagementDBA.Repository.Interface;
using HotelManagementModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementDBA.Repository
{
    public class LoginRepository:ILoginRepository
    {
        private readonly HotelManagementDBA.Database.HotelManagmentEntities _db;

        public LoginRepository()
        {
            _db =new  Database.HotelManagmentEntities();
        }

        public int Create(Login login)
        {
            if (login != null)
            {
                Database.Login ln = new Database.Login();
                ln.Email = login.Email;
                ln.Password = login.Password;
                ln.Is_Active = true;
                ln.Created_Date = DateTime.UtcNow;
                ln.Updated_Date = null;
                _db.Logins.Add(ln);
                _db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Delete(string email)
        {
            if (!email.Equals(null))
            {
                Database.Login login = _db.Logins.Find(email);
                _db.Logins.Remove(login);
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Login(string email, string password)
        {
            if(!email.Equals(null) && !password.Equals(null))
            {
                Database.Login login = _db.Logins.Find(email);
                if (login != null)
                {
                    if(password!=login.Password && email != login.Email)
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return 0;
            }
           

        }

        public int Update(Login login)
        {
            if (login != null)
            {
                Database.Login ln = _db.Logins.Find(login.Email);
               
                ln.Password = login.Password;
                ln.Updated_Date = DateTime.UtcNow;
                _db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
