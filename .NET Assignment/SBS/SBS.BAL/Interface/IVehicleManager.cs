using SBS.MDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BAL.Interface
{
    public interface IVehicleManager
    {
        bool AddVehicle(VehicleViewModel vehicle,int customerid);
        List<VehicleViewModel> GetVehicles(int customerid);
        List<Vehicle> GetVehiclesForDropDown(int customerid);
    }
}
