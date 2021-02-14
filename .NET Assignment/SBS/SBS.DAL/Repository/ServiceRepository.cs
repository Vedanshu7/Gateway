using SBS.DAL.Database;
using SBS.DAL.Interface;
using System;
using System.Collections.Generic;
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
        public List<Service> GetServicesForDropDown()
        {
            List<Service> services = _db.Services.ToList();
            return services;
        }
    }
}
