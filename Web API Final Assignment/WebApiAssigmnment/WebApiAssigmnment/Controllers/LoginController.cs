using HotelManagementInterface.Interface;
using HotelManagementModels.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiAssigmnment.Authentication;
using WebApiAssigmnment.Token;
using Authorization = WebApiAssigmnment.Authentication.Authorization;

namespace WebApiAssigmnment.Controllers
{
    public class LoginController : ApiController
    {
        private static ILogin loginManager;

        public LoginController(ILogin _login)
        {
            loginManager = _login;
        }

        [HttpPost]
        [Route("api/Register")]
        public HttpResponseMessage Register([FromBody] Login login)
        {
            if (login != null)
            {
                int i=loginManager.Create(login); if (i == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Profilr Created!!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Profile Not Created!!");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Date is Not Provided");
            }
        }
            // POST api/values
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Login login)
        {
            if (login != null)
            {
                int i = loginManager.Login(login.Email,login.Password);
                if (i == 2)
                {
                    Dictionary<string, string> keys = new Dictionary<string, string>();
                    keys.Add("Barear-Token", TokenManager.GenerateToken(login.Email));
                    return Request.CreateResponse(HttpStatusCode.OK, keys);
                }
                else if (i == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Email Or Password Does Not Matched!!");
                }
                else if (i == -1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Provide Email And Password");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Provide Email And Password");
                }
               
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Date is Not Provided");
            }
        }

        // PUT api/values/5
        [HttpPost]
        [Authorization]
        public HttpResponseMessage Put(string id, [FromBody] Login login)
        {
            if (!id.Equals(null) && login.Password != null)
            {
                login.Email = id;
                int i=loginManager.Update(login);
                if (i == 1) {
                    return Request.CreateResponse(HttpStatusCode.OK, "Password Updated!!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Password Not Updated!!");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Date is Not Provided");
            }
        }

        // DELETE api/values/5
        [HttpDelete]
        [Authorization]
        public HttpResponseMessage Delete(string id)
        {
            if (id != "")
            {
                int i = loginManager.Delete(id);
                if (i == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Profile Deleted!!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Profile Not Deleted!!");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Date is Not Provided");
            }

        }
    }
}
