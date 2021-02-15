using SBS.MDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BAL.Interface
{
    public interface IMechanicManager
    {
        List<MechanicViewModel> GetMechanics(int dealerId);
        bool DeleteMechanic(int id);
        MechanicViewModel GetMechanic(int id);
        bool EditMechanic(MechanicViewModel mechanic);
        bool CreateMechanic(MechanicViewModel mechanic);
    }
}
