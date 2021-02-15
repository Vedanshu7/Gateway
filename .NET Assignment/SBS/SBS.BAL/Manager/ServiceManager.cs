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
                cfg.CreateMap<DAL.Database.Service, ServiceViewModel>();
                cfg.CreateMap<ServiceViewModel, DAL.Database.Service>();
            });
            mapper = config.CreateMapper();
        }

        public bool CreateService(ServiceViewModel service)
        {
            DAL.Database.Service servicefordb = mapper.Map<ServiceViewModel, DAL.Database.Service>(service);
            return _ServiceRepository.CreateService(servicefordb);
        }

        public bool DeleteService(int id)
        {
            return _ServiceRepository.DeleteService(id);
        }

        public bool EditService(ServiceViewModel service)
        {
            DAL.Database.Service servicefordb = mapper.Map<ServiceViewModel, DAL.Database.Service>(service);
            return _ServiceRepository.EditService(servicefordb);
        }

        public ServiceViewModel GetService(int id)
        {
            ServiceViewModel service = mapper.Map<DAL.Database.Service, ServiceViewModel>(_ServiceRepository.GetService(id));
            return service;
        }

        public List<ServiceViewModel> GetServices()
        {
            List<DAL.Database.Service> servicesfromdb = _ServiceRepository.GetServices();
            List<ServiceViewModel> services = mapper.Map<List<DAL.Database.Service>, List<ServiceViewModel>>(servicesfromdb);
            return services;
        }

        public List<Service> GetServicesForDropDown()
        {
            List<DAL.Database.Service> servicesfromdb = _ServiceRepository.GetServicesForDropDown();
            List<MDL.Models.Service> services = mapper.Map<List<DAL.Database.Service>, List<MDL.Models.Service>>(servicesfromdb);
            return services;
        }
    }
}
