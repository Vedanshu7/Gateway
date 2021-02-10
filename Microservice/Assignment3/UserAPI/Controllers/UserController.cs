using CommonObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using UserAPI.Services;


namespace UserAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<UserDetailsDto> Get()
        {
            return new UserService().GetUsers().Select(c => new UserDetailsDto { Id = c.Id, Name = c.Email ,MobileNumber=c.MobileNumber});
        }

    }
}
