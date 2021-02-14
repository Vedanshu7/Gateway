using SBS.DAL.Database;
using SBS.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL.Repository
{
    public class DealerRepository : IDealerRepository
    {
        private readonly Database.SBSEntities _db;
        public DealerRepository()
        {
            _db = new Database.SBSEntities();
        }
        public List<Dealer> GetDealersForDropDown()
        {
            List<Dealer> dealers = _db.Dealers.ToList();
            return dealers;
        }
    }
}
