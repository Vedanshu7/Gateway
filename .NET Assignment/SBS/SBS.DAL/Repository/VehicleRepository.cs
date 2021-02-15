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

        public bool DeleteVehicle(int id,int customerId)
        {
            Vehicle vehicle = _db.Vehicles.Where(v => v.Id == id && v.Cust_Id == customerId).FirstOrDefault();
            var result = _db.Vehicles.Remove(vehicle);
            if (result != null)
            {
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public Vehicle GetVehicle(int id, int customerId)
        {
            var vehicle = _db.Vehicles.Where(v => v.Cust_Id == customerId && v.Id == id).FirstOrDefault();
            return vehicle;
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

        public bool UpdateVehicle(Vehicle vehicle)
        {
            var vehiclefromdb = _db.Vehicles.Where(v => v.Id == vehicle.Id).FirstOrDefault();
            if (vehiclefromdb != null)
            {
                vehiclefromdb.Chessi_Number = vehicle.Chessi_Number;
                vehiclefromdb.LicensePlate = vehicle.LicensePlate;
                vehiclefromdb.Make = vehicle.Make;
                vehiclefromdb.Model = vehicle.Model;
                vehiclefromdb.OwnerName = vehicle.OwnerName;
                vehiclefromdb.RegistrationDate = vehicle.RegistrationDate;
                _db.Entry(vehiclefromdb).State = EntityState.Modified;
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
