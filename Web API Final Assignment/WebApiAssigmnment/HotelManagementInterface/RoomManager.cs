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
    public class RoomManager : IRoom
    {
        private readonly IRoomRepository roomRepository;

        
        public RoomManager(IRoomRepository _roomRepository)
        {
            roomRepository = _roomRepository;
        }
        public bool Availability(int id,DateTime? date)
        {
            return roomRepository.Availability(id,date);
        }

        public int AddRooms(List<Room> rooms)
        {
            return roomRepository.AddRooms(rooms);
        }

        public int BookRoom(int id, DateTime date, string status)
        {
            return roomRepository.BookRoom(id, date, status);
        }

        public List<Room> GetRoom(int hotel_id)
        {
            return roomRepository.GetRoom(hotel_id);
        }
    }
}
