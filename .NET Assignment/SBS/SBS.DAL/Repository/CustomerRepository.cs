using SBS.DAL.Database;
using SBS.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Database.SBSEntities _db;
        public CustomerRepository()
        {
            _db = new Database.SBSEntities();
        }

        public bool CreateCustomer(Customer customer)
        {
            customer.CreatedDate = DateTime.Now;
            customer.IsActive = true;
            _db.Customers.Add(customer);
            _db.SaveChanges();
            return true;
        }

        public bool DeleteCustomer(int id)
        {
            Customer customer = _db.Customers.Find(id);
            if (customer != null)
            {
                _db.Customers.Remove(customer);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool EditCustomer(Customer customer)
        {
            Customer customerfromdb = _db.Customers.Where(c => c.Id == customer.Id).FirstOrDefault();
            if (customerfromdb != null)
            {
                customerfromdb.Email = customer.Email;
                customerfromdb.Address = customer.Address;
                customerfromdb.City = customer.City;
                customerfromdb.FirstName = customer.FirstName;
                customerfromdb.LastName = customer.LastName;
                customerfromdb.Password = customer.Password;
                customerfromdb.State = customer.State;
                customerfromdb.Phone = customer.Phone;
                customerfromdb.City = customer.City;
                customerfromdb.ZipCode = customer.ZipCode;
                customerfromdb.UpdatedDate = DateTime.Now;
                customerfromdb.IsActive = true;
                //_db.Entry(customerfromdb).State = EntityState.Modified;
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public Customer GetCustomer(int id)
        {
            Customer customer = _db.Customers.Find(id);
            return customer;
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> customers = _db.Customers.ToList();
            return customers;
        }
    }
}
