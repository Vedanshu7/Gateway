using NLog;
using ProductInterface.Interface;
using ProductModel.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductApi.Controllers
{
    public class RegisterController : ApiController
    {
        private readonly ILoginManager _loginmanager;

        private static Logger Login_Logger = LogManager.GetCurrentClassLogger();

        public RegisterController(ILoginManager loginManager)
        {
            _loginmanager = loginManager;
        }
        // GET: Register
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Register l)
        {
            if (l != null)
            {
                Login_Logger.Info(l.Email + " : register done");
                return Request.CreateResponse(HttpStatusCode.OK, _loginmanager.Register(l));
            }
            else
            {
                Login_Logger.Warn(l.Email + " : registration fail");
                return Request.CreateResponse(HttpStatusCode.NotFound, "404");

            }
        }

    }
}
