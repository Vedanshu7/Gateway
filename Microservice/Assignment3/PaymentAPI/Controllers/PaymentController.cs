using CommonObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        public IEnumerable<UserDetailsDto> Get()
        {
            return new PaymentService().GetPayments().Select(c => new UserDetailsDto { Id = c.Id });
        }
    }
}
