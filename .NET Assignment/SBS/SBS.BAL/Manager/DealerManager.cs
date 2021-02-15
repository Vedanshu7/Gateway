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
                cfg.CreateMap<DAL.Database.Dealer, MDL.Models.DealerViewModel>();
                cfg.CreateMap<MDL.Models.DealerViewModel, DAL.Database.Dealer>();
            });
            mapper = config.CreateMapper();
        }

        public bool CreateDealer(DealerViewModel dealer)
        {
            DAL.Database.Dealer dealerfordb = mapper.Map<DealerViewModel, DAL.Database.Dealer>(dealer);
            return _DealerRepository.CreateDealer(dealerfordb);
        }

        public bool DeleteDealer(int id)
        {
            return _DealerRepository.DeleteDealer(id);
        }

        public bool EditDealer(DealerViewModel dealer)
        {
            DAL.Database.Dealer dealerfordb = mapper.Map<DealerViewModel, DAL.Database.Dealer>(dealer);
            return _DealerRepository.EditDealer(dealerfordb);
        }

        public DealerViewModel GetDealer(int dealerId)
        {
            DAL.Database.Dealer dealerfromdb = _DealerRepository.GetDealer(dealerId);
            DealerViewModel dealer = mapper.Map<DAL.Database.Dealer, DealerViewModel>(dealerfromdb);
            return dealer;
        }

        public List<DealerViewModel> GetDealers()
        {
            List<DAL.Database.Dealer> dealersfromdb = _DealerRepository.GetDealers();
            List<MDL.Models.DealerViewModel> dealers = mapper.Map<List<DAL.Database.Dealer>, List<MDL.Models.DealerViewModel>>(dealersfromdb);
            return dealers;
        }

        public List<Dealer> GetDealersForDropDown()
        {
            List<DAL.Database.Dealer> dealersfromdb = _DealerRepository.GetDealersForDropDown();
            List<MDL.Models.Dealer> dealers = mapper.Map<List<DAL.Database.Dealer>, List<MDL.Models.Dealer>>(dealersfromdb);
            return dealers;
        }
    }
}
