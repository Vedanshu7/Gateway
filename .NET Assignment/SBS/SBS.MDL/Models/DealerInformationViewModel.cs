using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.MDL.Models
{
    public class DealerInformationViewModel
    {
        public DealerViewModel dealer { get; set;}
        public List<BookAppointment> appointments { get; set; }
        public List<MechanicViewModel> mechanics { get; set; }
    }
}
