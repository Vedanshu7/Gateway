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
    public class ServiceRepository : IServiceRepository
    {
        private readonly Database.SBSEntities _db;
        public ServiceRepository()
        {
            _db = new Database.SBSEntities();
        }

        public bool CreateService(Service service)
        {
            try
            {
                _db.Services.Add(service);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteService(int id)
        {
            Service service = _db.Services.Find(id);
            if (service != null)
            {
                _db.Services.Remove(service);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool EditService(Service service)
        {
            Service servicefromdb = _db.Services.Find(service.Id);
            if (servicefromdb != null)
            {
                servicefromdb.Name = service.Name;
                servicefromdb.Price = service.Price;
                servicefromdb.Duration = service.Duration;
                servicefromdb.Active = service.Active;
                _db.Entry(servicefromdb).State = EntityState.Modified;
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public Service GetService(int id)
        {
            Service service = _db.Services.Find(id);
            return service;
        }

        public List<Service> GetServices()
        {
            List<Service> services = _db.Services.ToList();
            return services;
        }

        public List<Service> GetServicesForDropDown()
        {
            List<Service> services = _db.Services.ToList();
            return services;
        }
    }
}
