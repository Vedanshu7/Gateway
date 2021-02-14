using AutoMapper;
using SBS.BAL.Interface;
using SBS.DAL.Interface;
using SBS.MDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BAL.Manager
{
    public class ServiceManager:IServiceManager
    {
        private readonly IServiceRepository _ServiceRepository;
        public IMapper mapper;
        public MapperConfiguration config;

        public ServiceManager(IServiceRepository serviceRepository)
        {
            _ServiceRepository = serviceRepository;
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DAL.Database.Service,MDL.Models.Service>();
            });
            mapper = config.CreateMapper();
        }

        public List<Service> GetServicesForDropDown()
        {
            List<DAL.Database.Service> servicesfromdb = _ServiceRepository.GetServicesForDropDown();
            List<MDL.Models.Service> services = mapper.Map<List<DAL.Database.Service>, List<MDL.Models.Service>>(servicesfromdb);
            return services;
        }
    }
}
