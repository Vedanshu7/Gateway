using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementDBA.Interface
{
    public interface IBookingRepository
    {
        int Update_Booking(int room_id, System.DateTime date,string status);

        int Delete_Booking(int booking_id);
    }
}
