using HotelManagementModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementInterface.Interface
{
    public interface IRoom
    {
        bool Availability(int id,System.DateTime? date);

        int BookRoom(int id, System.DateTime date,string status);

        int AddRooms(List<Room> rooms);

        List<Room> GetRoom(int hotel_id);
    }
}
