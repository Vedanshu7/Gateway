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
    public class MechanicRepository : IMechanicRepository
    {
        private readonly Database.SBSEntities _db;
        public MechanicRepository()
        {
            _db = new Database.SBSEntities();
        }

        public bool CreateMechanic(Mechanic mechanic)
        {
            if (mechanic != null)
            {
                _db.Mechanics.Add(mechanic);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteMechanic(int id)
        {
            Mechanic mechanicfromdb = _db.Mechanics.Find(id);
            if (mechanicfromdb != null)
            {
                _db.Mechanics.Remove(mechanicfromdb);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool EditMechanic(Mechanic mechanic)
        {
            Mechanic mechanicfromdb = _db.Mechanics.Find(mechanic.Id);
            if (mechanicfromdb != null)
            {
                mechanicfromdb.FirstName = mechanic.FirstName;
                mechanicfromdb.LastName = mechanic.LastName;
                mechanicfromdb.MobileNo = mechanic.MobileNo;
                mechanicfromdb.MechanicNo = mechanic.MechanicNo;
                mechanicfromdb.Email = mechanic.Email;
                mechanicfromdb.Dealer_Id = mechanic.Dealer_Id;
                _db.Entry(mechanicfromdb).State = EntityState.Modified;
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public Mechanic GetMechanic(int id)
        {
            Mechanic mechanic = _db.Mechanics.Find(id);
            return mechanic;
        }

        public List<Mechanic> GetMechanics(int dealerId)
        {
            List<Mechanic> mechanics = _db.Mechanics.Where(m => m.Dealer_Id == dealerId).ToList();
            return mechanics;
        }
    }
}
