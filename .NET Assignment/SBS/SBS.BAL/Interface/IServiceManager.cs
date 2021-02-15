using SBS.MDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BAL.Interface
{
    public interface IServiceManager
    {
        List<Service> GetServicesForDropDown();
        List<ServiceViewModel> GetServices();
        ServiceViewModel GetService(int id);
        bool DeleteService(int id);
        bool CreateService(ServiceViewModel service);
        bool EditService(ServiceViewModel service);
    }
}
