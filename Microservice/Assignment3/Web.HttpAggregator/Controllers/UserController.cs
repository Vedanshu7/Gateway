using CommonObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.HttpAggregator.Attributes;
using Web.HttpAggregator.Util;

namespace Web.HttpAggregator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [RateLimit(Name = "Limit Request Number", Seconds = 5)]
        public async Task<IEnumerable<UserDetailsDto>> GetEntity()
        {
            var users = await HttpCall.GetRequest<List<UserDetailsDto>>("https://localhost:44390/user");
            var booking = await HttpCall.GetRequest<List<UserDetailsDto>>("https://localhost:44310/booking");
            var payment = await HttpCall.GetRequest<List<UserDetailsDto>>("https://localhost:44318/payment");
            var driver = await HttpCall.GetRequest<List<UserDetailsDto>>("https://localhost:44319/driver");

            users.AddRange(booking);
            users.AddRange(payment);
            users.AddRange(driver);

            return users;
        }
    }
}
