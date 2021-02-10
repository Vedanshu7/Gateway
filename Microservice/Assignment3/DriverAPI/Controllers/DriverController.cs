using CommonObjects;
using DriverAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<UserDetailsDto> Get()
        {
            return new DriverService().GetDrivers().Select(c => new UserDetailsDto { Id = c.Id, Name = c.Email, MobileNumber = c.MobileNumber });
        }
    }
}
