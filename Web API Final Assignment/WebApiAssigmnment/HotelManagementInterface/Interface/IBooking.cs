using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementInterface.Interface
{
    public interface IBooking
    {
        int Update_Booking(int room_id, System.DateTime date,string status);

        int Delete_Booking(int booking_id);
    }
}
