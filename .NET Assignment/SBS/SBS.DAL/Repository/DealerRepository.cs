using SBS.DAL.Database;
using SBS.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public bool CreateDealer(Dealer dealer)
        {
            try
            {
                _db.Dealers.Add(dealer);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteDealer(int id)
        {
            Dealer dealer = _db.Dealers.Find(id);
            var result=_db.Dealers.Remove(dealer);
            if (result != null)
            {
                return true;
            }
            return false;
        }

        public bool EditDealer(Dealer dealer)
        {
            var deaelrfromdb = _db.Dealers.Find(dealer.Id);
            if (deaelrfromdb != null)
            {
                deaelrfromdb.FirstName = dealer.FirstName;
                deaelrfromdb.LastName = dealer.LastName;
                deaelrfromdb.Email = dealer.Email;
                deaelrfromdb.HomePhone = dealer.HomePhone;
                deaelrfromdb.Note = dealer.Note;
                deaelrfromdb.ZipCode = dealer.ZipCode;
                deaelrfromdb.Address = dealer.Address; 
                _db.Entry(deaelrfromdb).State = EntityState.Modified;
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public Dealer GetDealer(int dealerId)
        {
            Dealer dealer = _db.Dealers.Where(d => d.Id == dealerId).FirstOrDefault();
            return dealer;
        }

        public List<Dealer> GetDealers()
        {
            List<Dealer> dealers = _db.Dealers.ToList();
            return dealers;
        }

        public List<Dealer> GetDealersForDropDown()
        {
            List<Dealer> dealers = _db.Dealers.ToList();
            return dealers;
        }
    }
}
