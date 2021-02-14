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
    public class DealerManager:IDealerManager
    {
        private readonly IDealerRepository _DealerRepository;
        public IMapper mapper;
        public MapperConfiguration config;

        public DealerManager(IDealerRepository dealerRepository)
        {
            _DealerRepository = dealerRepository;
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DAL.Database.Dealer, MDL.Models.Dealer>();
            });
            mapper = config.CreateMapper();
        }

        public List<Dealer> GetDealersForDropDown()
        {
            List<DAL.Database.Dealer> dealersfromdb = _DealerRepository.GetDealersForDropDown();
            List<MDL.Models.Dealer> dealers = mapper.Map<List<DAL.Database.Dealer>, List<MDL.Models.Dealer>>(dealersfromdb);
            return dealers;
        }
    }
}
