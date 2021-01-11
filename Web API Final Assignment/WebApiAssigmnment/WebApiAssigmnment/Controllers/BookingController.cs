using HotelManagementInterface.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiAssigmnment.Authentication;
using Authorization = WebApiAssigmnment.Authentication.Authorization;

namespace WebApiAssigmnment.Controllers
{
    public class BookingController : ApiController
    {
        private static IBooking booking;

        public BookingController(IBooking _booking)
        {
            booking = _booking;
        }

        [HttpPut]
        [Route("api/Booking/{id}/{date}/{status?}")]
        [Authorization]
        // PUT: api/Booking/5
        public HttpResponseMessage Put(int id,DateTime date,string status="")
        {
            if(!id.Equals(null)  && !date.Equals(null))
            {
                int i = booking.Update_Booking(id, date, status);
                if (i == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Booking Date Changed Successfully!!");
                }
                else if (i == -1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Booking Status Changed Successfully!!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "Request Failed");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotModified, "Request Failed");
            }

        }

        // DELETE: api/Booking/5
        [HttpDelete]
        [Authorization]
        public HttpResponseMessage Delete(int id)
        {
            if (!id.Equals(null))
            {
                int i = booking.Delete_Booking(id);
                if (i == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Booking Deleted Successfully!!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "Request Failed");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotModified, "Request Failed");
            }
            
        }
    }
}
