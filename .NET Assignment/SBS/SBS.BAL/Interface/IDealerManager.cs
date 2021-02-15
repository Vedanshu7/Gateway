using SBS.MDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BAL.Interface
{
    public interface IDealerManager
    {
        List<Dealer> GetDealersForDropDown();
        List<DealerViewModel> GetDealers();
        DealerViewModel GetDealer(int dealerId);
        bool DeleteDealer(int id);
        bool EditDealer(DealerViewModel dealer);
        bool CreateDealer(DealerViewModel dealer);
    }
}
