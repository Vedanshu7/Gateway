using SBS.DAL.Database;
using SBS.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly Database.SBSEntities _db;
        public VehicleRepository()
        {
            _db = new Database.SBSEntities();
        }
        public bool AddVehicle(Vehicle vehicle,int customerid)
        {
            try
            {
                vehicle.Cust_Id = customerid;
                _db.Vehicles.Add(vehicle);
                _db.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public List<Vehicle> GetVehicles(int customerid)
        {
            try
            {
                List<Vehicle> vehicles = _db.Vehicles.Where(v => v.Cust_Id == customerid).ToList();
                return vehicles;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public List<Vehicle> GetVehiclesForDropDown(int customerId)
        {
            List<Vehicle> vehicles = _db.Vehicles.Where(v => v.Cust_Id == customerId).ToList();
            return vehicles;
        }
    }
}
