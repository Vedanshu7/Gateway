using BookingAPI.Services;
using CommonObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<UserDetailsDto> Get()
        {
            return new BookingService().GetBookings().Select(c => new UserDetailsDto { Id = c.UserId });
        }
    }
}
