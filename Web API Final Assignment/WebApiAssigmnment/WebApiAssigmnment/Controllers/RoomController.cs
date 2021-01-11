using HotelManagementInterface.Interface;
using HotelManagementModels.Model;
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
    public class RoomController : ApiController
    {
        private static IRoom room;

        public RoomController(IRoom _room)
        {
            room = _room;
        }
        [HttpPost]
        [Route("api/Room")]
        [Authorization]
        public HttpResponseMessage Post([FromBody]List<Room> rooms)
        {
            if (rooms != null)
            {
                int i = room.AddRooms(rooms);
                if (i == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, "Rooms Are Successfully Added!!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,"Request Failed");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Request Failed");
            }
            
        }

        [HttpGet]
        [Route("api/Room/availability/{id}/{date?}")]
        [Authorization]
        public HttpResponseMessage availability(int id,DateTime? date=null)
        {
            if (!id.Equals(null))
            {
                bool b = room.Availability(id, date);
                if (b)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, true);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, false);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, false);
            }
            
        }


        [HttpPost]
        [Route("api/Room/BookRoom/{id:int}/{date:DateTime}/{status?}")]
        [Authorization]
        public HttpResponseMessage BookRoom(int id, DateTime date, string status="")
        {
            if(!id.Equals(null) && !date.Equals(null))
            {
                int i = room.BookRoom(id, date, status);
                if (i == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Room Is Booked On Specified Date!!!");
                }
                else if (i == -1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Room Is Not Available On Specified Date!!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "No Room Found On Specified Room Id");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Invalid Input!!");
            }
            
        }
       
    }
}
