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
    public class HotelController : ApiController
    {
        private static IHotel hotel;
        
        public HotelController(IHotel _hotel)
        {
            hotel = _hotel;
        }
        [Authorization]
        public HttpResponseMessage Post([FromBody]List<Hotel> hotels)
        {
            if (hotels != null) {
                int i = hotel.AddHotels(hotels);
                if (i == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.Created,"Hotels Added Successfully!!!" );
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Reuest Failed!!");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound,"Provided List Is Null" );
            }
           
        }

        [HttpGet]
        [Route("api/Hotel")]
        [Authorization]
        public HttpResponseMessage Get()
        {
            List<Hotel> hotels = hotel.GetAllHotels();
            if (hotels != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK,hotels);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Hotels Not Found!!");
            }
            
        }

        [HttpGet]
        [Route("api/Hotel/GetRoomsOfHotels/{param?}/{id?}")]
        [Authorization]
        public HttpResponseMessage GetRoomsOfHotels(string param="",string id="")
        {
            List<Dictionary<string, string>> d = hotel.Hotels(param, id);
            if (d != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK,d );
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK,"No Hotel Rooms Are Found!!" );
            }
            
        }
       
    }
}
