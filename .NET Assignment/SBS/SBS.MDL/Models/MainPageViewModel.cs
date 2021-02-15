using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.MDL.Models
{
    public class MainPageViewModel
    {
        public List<DealerViewModel> dealers { get; set; }
        public List<RegisterViewModel> customers { get; set; }
        public List<ServiceViewModel> services { get; set; }
    }
}
