using HotelManagementDBA.Interface;
using HotelManagementModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementDBA.Repository
{
    public class RoomRepository:IRoomRepository
    {
        private readonly HotelManagementDBA.Database.HotelManagmentEntities _db;

        public RoomRepository()
        {
            _db = new HotelManagementDBA.Database.HotelManagmentEntities();
        }
        public int AddRooms(List<Room> rooms)
        {
            if (rooms != null)
            {
                for (int i = 0; i < rooms.Count; i++)
                {
                    Database.Room r = new Database.Room();

                    r.Name = rooms[i].Name;
                    r.Category = rooms[i].Category;
                    r.Price = rooms[i].Price;
                    r.IsActive = rooms[i].IsActive;
                    r.Created_Date = DateTime.UtcNow;
                    r.Created_By = rooms[i].Created_By;
                    r.Hotel_Id = rooms[i].Hotel_Id;
                    r.Updated_By = null;
                    r.Updated_Date = null;

                    _db.Rooms.Add(r);
                }
                _db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public List<Room> GetRoom(int hotel_id)
        {
            List<Database.Room> rooms = _db.Rooms.Where(i => i.Hotel_Id == hotel_id).ToList();
            if (rooms != null)
            {
                List<Room> _rooms = new List<Room>();
                for(int i = 0; i < rooms.Count; i++)
                {
                    Room r = new Room();


                    rooms[i].Name = r.Name;
                    rooms[i].Category=r.Category;
                    rooms[i].Price=r.Price;
                    rooms[i].IsActive=r.IsActive;
                    rooms[i].Created_Date=r.Created_Date;
                    rooms[i].Created_By=r.Created_By;
                    rooms[i].Updated_By=r.Updated_By;
                    rooms[i].Updated_Date=r.Updated_Date;

                    _rooms.Add(r);
                }

                return _rooms;
            }
            else
            {
                return null;
            }
           
        }
        public bool Availability(int id,DateTime? date)
        {
            if (!id.Equals(null))
            {
                var jointabel = _db.Rooms.Join(_db.Bookings, r => r.Id, b => b.Room_Id, (r, b) =>
           new {
               Booking_Date = b.Booking_Date,
               Room_Id = r.Id,
               Status = b.Status
           }).ToList();
                bool flag = true;
                for (int i = 0; i < jointabel.Count; i++)
                {
                    if (date != null)
                    {
                        if (jointabel[i].Booking_Date == date && jointabel[i].Room_Id == id && (jointabel[i].Status != "Deleted" || jointabel[i].Status != "Cancelled"))
                        {
                            flag = false;
                        }
                    }
                    else
                    {
                        if (jointabel[i].Room_Id == id && (jointabel[i].Status != "Deleted" || jointabel[i].Status != "Cancelled"))
                        {
                            flag = false;
                        }
                    }

                }
                return flag;
            }
            else
            {
                return false;
            }
           
        }

        public int BookRoom(int id, DateTime date, string status)
        {
            var room = _db.Rooms.Find(id);
            if (Availability(id, date))
            {
                if (room != null)
                {
                    Database.Booking booking = new Database.Booking();
                    booking.Booking_Date = date;
                    booking.Room_Id = id;
                    if (status != "")
                    {
                        booking.Status = status;
                    }
                    else
                    {
                        booking.Status = "Default";
                    }
                    _db.Bookings.Add(booking);
                    _db.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return -1;
            }
        }
    }
}
