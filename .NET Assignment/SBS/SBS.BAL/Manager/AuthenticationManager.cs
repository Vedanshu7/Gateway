using AutoMapper;
using SBS.BAL.Interface;
using SBS.Common.CommonModels;
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
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        public IMapper mapper;
        public MapperConfiguration config;

        public AuthenticationManager(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LoginViewModel, Customer>();
                cfg.CreateMap<RegisterViewModel, Customer>();
                cfg.CreateMap<VehicleViewModel, DAL.Database.Vehicle>();
            });
            mapper = config.CreateMapper();
        }

        public LoginResult Login(LoginViewModel login)
        {
            Customer customer = mapper.Map<LoginViewModel, Customer>(login);
            return _authenticationRepository.Login(customer);
        }

        public bool Register(RegisterViewModel register, VehicleViewModel vehicle)
        {
            Customer customerfordb = mapper.Map<RegisterViewModel, Customer>(register);
            DAL.Database.Vehicle vehiclefordb = new DAL.Database.Vehicle();
            if (vehicle != null)
            {
                vehiclefordb = mapper.Map<VehicleViewModel, DAL.Database.Vehicle>(vehicle);
            }
            return _authenticationRepository.Register(customerfordb, vehiclefordb);

        }
    }
}
