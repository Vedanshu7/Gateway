using SBS.DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL.Interface
{
    public interface IVehicleRepository
    {
        bool AddVehicle(Vehicle vehicle,int customerid);
        List<Vehicle> GetVehicles(int customerid);
        List<Vehicle> GetVehiclesForDropDown(int customerid);
        Vehicle GetVehicle(int id, int customerId);
        bool UpdateVehicle(Vehicle vehicle);
        bool DeleteVehicle(int id,int customerId);
    }
}
