using SBS.DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL.Interface
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();
        Customer GetCustomer(int id);
        bool DeleteCustomer(int id);
        bool EditCustomer(Customer customer);
        bool CreateCustomer(Customer customer);
    }
}
