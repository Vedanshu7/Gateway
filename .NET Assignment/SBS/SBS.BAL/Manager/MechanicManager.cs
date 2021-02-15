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
    public class MechanicManager:IMechanicManager
    {
        private readonly IMechanicRepository _MechanicRepository;
        public IMapper mapper;
        public MapperConfiguration config;

        public MechanicManager(IMechanicRepository mechanicRepository)
        {
            _MechanicRepository = mechanicRepository;
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DAL.Database.Mechanic, MDL.Models.MechanicViewModel>();
            });
            mapper = config.CreateMapper();
        }

        public bool CreateMechanic(MechanicViewModel mechanic)
        {
            Mechanic mechanicfordb = mapper.Map<MechanicViewModel, Mechanic>(mechanic);
            return _MechanicRepository.CreateMechanic(mechanicfordb);
        }

        public bool DeleteMechanic(int id)
        {
            return _MechanicRepository.DeleteMechanic(id);
        }

        public bool EditMechanic(MechanicViewModel mechanic)
        {
            Mechanic mechanicfordb = mapper.Map<MechanicViewModel, Mechanic>(mechanic);
            return _MechanicRepository.EditMechanic(mechanicfordb);
        }

        public MechanicViewModel GetMechanic(int id)
        {
            Mechanic mechanicsfromdb = _MechanicRepository.GetMechanic(id);
            MechanicViewModel mechanic = mapper.Map<Mechanic,MechanicViewModel>(mechanicsfromdb);
            return mechanic;
        }

        public List<MechanicViewModel> GetMechanics(int dealerId)
        {
            List<Mechanic> mechanicsfromdb = _MechanicRepository.GetMechanics(dealerId);
            List<MechanicViewModel> mechanics = mapper.Map<List<Mechanic>, List<MechanicViewModel>>(mechanicsfromdb);
            return mechanics;
        }
    }
}
