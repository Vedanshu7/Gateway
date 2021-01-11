using HotelManagementModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementInterface.Interface
{
    public interface IHotel
    {
        int AddHotels(List<Hotel> hotels);

        List<Hotel> GetAllHotels();

        List<Dictionary<string, string>> Hotels(string param,string where);

       
    }
}
