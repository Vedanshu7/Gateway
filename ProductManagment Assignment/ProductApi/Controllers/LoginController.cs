using ProductApi.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductInterface.Interface;
using ProductModels.Models;
using Newtonsoft.Json;
using ProductApi.Authentication;
using Authorization = ProductApi.Authentication.Authorization;
using NLog;
using ProductModel.Models;

namespace ProductApi.Controllers
{
    public class LoginController : ApiController
    {
        private readonly ILoginManager _loginmanager;

        private static Logger Login_Logger = LogManager.GetCurrentClassLogger();

        public LoginController(ILoginManager loginManager)
        {
            _loginmanager = loginManager;
        }
        // GET api/values
        [HttpGet]
        [Authorization]
        public HttpResponseMessage GetUser(string email)
        {
            if (email != null)
            {
                
                return Request.CreateResponse(HttpStatusCode.OK, _loginmanager.GetUser(email)) ;
            }
            else
            {
                
                return Request.CreateResponse(HttpStatusCode.NotFound, "404");
            }
            
        }
       
       

        // GET api/values/5
        [HttpPost]
        public HttpResponseMessage GetLogin([FromBody]Login l)
        {
            Login login = _loginmanager.GetUser(l.Email);
            if (login != null)
            {
                if (login.Password != l.Password)
                {
                    Login_Logger.Info(l.Email + " : Passwords doesn't match");
                    return Request.CreateResponse(HttpStatusCode.NotFound, "404");
                }
                else
                {
                    Login_Logger.Info(l.Email + " : is Successfully Loged In");
                    return Request.CreateResponse(HttpStatusCode.OK, TokenManager.GenerateToken(l.Email));
                }
            }
            else
            {
                Login_Logger.Warn(l.Email + " : is Login Fail");
                return Request.CreateResponse(HttpStatusCode.NotFound, "404");
            }

        }

      
    }
}
