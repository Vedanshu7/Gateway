using SBS.DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL.Interface
{
    public interface IServiceRepository
    {
        List<Service> GetServicesForDropDown();
        List<Service> GetServices();
        Service GetService(int id);
        bool DeleteService(int id);
        bool CreateService(Service service);
        bool EditService(Service service);
    }
}
