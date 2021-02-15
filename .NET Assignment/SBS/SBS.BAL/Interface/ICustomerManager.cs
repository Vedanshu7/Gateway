using SBS.MDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BAL.Interface
{
    public interface ICustomerManager
    {
        List<RegisterViewModel> GetCustomers();
        RegisterViewModel GetCustomer(int id);
        bool DeleteCustomer(int id);
        bool EditCustomer(RegisterViewModel customer);
        bool CreateCustomer(RegisterViewModel customer);
    }
}
