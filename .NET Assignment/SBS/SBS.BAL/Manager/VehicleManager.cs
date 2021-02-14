using AutoMapper;
using SBS.BAL.Interface;
using SBS.DAL.Database;
using SBS.DAL.Interface;
using SBS.MDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BAL.Manager
{
    public class VehicleManager : IVehicleManager
    {
        private readonly IVehicleRepository _vehicleRepository;
        public IMapper mapper;
        public MapperConfiguration config;

        public VehicleManager(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VehicleViewModel, DAL.Database.Vehicle>();
                cfg.CreateMap<DAL.Database.Vehicle, VehicleViewModel>();
                cfg.CreateMap<DAL.Database.Vehicle, MDL.Models.Vehicle>();
            });
            mapper = config.CreateMapper();
        }
        public bool AddVehicle(VehicleViewModel vehicle ,int customerid)
        {
            DAL.Database.Vehicle vehiclefordb = mapper.Map<VehicleViewModel, DAL.Database.Vehicle>(vehicle);
            var result = _vehicleRepository.AddVehicle(vehiclefordb,customerid);
            return result;
        }

        public List<VehicleViewModel> GetVehicles(int customerid)
        {
            List<DAL.Database.Vehicle> vehiclesfromdb = _vehicleRepository.GetVehicles(customerid);
            List<VehicleViewModel> vehicles = mapper.Map<List<DAL.Database.Vehicle>,List<VehicleViewModel>>(vehiclesfromdb);
            return vehicles;
        }

        public List<MDL.Models.Vehicle> GetVehiclesForDropDown(int customerid)
        {
            List<DAL.Database.Vehicle> vehiclesfromdb = _vehicleRepository.GetVehiclesForDropDown(customerid);
            List<MDL.Models.Vehicle> vehicles = mapper.Map<List<DAL.Database.Vehicle>, List<MDL.Models.Vehicle>>(vehiclesfromdb);
            return vehicles;
        }
    }
}
