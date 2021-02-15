using SBS.DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL.Interface
{
    public interface IMechanicRepository
    {
        List<Mechanic> GetMechanics(int dealerId);
        bool DeleteMechanic(int id);
        Mechanic GetMechanic(int id);
        bool EditMechanic(Mechanic mechanic);
        bool CreateMechanic(Mechanic mechanic);
    }
}
