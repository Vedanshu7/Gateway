using HotelManagementDBA.Interface;
using HotelManagementInterface.Interface;
using HotelManagementModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementInterface
{
    public class HotelManager : IHotel
    {
        private readonly IHotelRepository hotelRepository;

        public HotelManager(IHotelRepository _hotelRepository)
        {
            hotelRepository = _hotelRepository;
        }

        public int AddHotels(List<Hotel> hotels)
        {
            return hotelRepository.AddHotels(hotels);
        }

        public List<Hotel> GetAllHotels()
        {
            return hotelRepository.GetAllHotels();
        }

        public List<Dictionary<string, string>> Hotels(string param,string where)
        {
            return hotelRepository.Hotels(param,where);
        }
    }
}
