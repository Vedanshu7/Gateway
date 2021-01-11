using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Results;
using WebApiAssigmnment.Token;

namespace WebApiAssigmnment.Authentication
{
    public class Authorization : AuthorizeAttribute, IAuthenticationFilter
    {
        public override bool AllowMultiple
        {
            get
            {
                return false;
            }
        }
        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            string authParam = string.Empty;
            HttpRequestMessage request = context.Request;
            string[] TokenArray = null;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;

            if (authorization == null)
            {
                context.ErrorResult = new AuthenticationFaliurResult("Missing Authorization Header", request);
                return;
            }
            if (authorization.Scheme != "Bearer")
            {
                context.ErrorResult = new AuthenticationFaliurResult("Invalid Authorization", request);
                return;
            }
            TokenArray = authorization.Parameter.Split(':');
            string token = TokenArray[0].Replace('\\', ' ');
            token = token.Replace('"', ' ');
            token = token.Trim();
            string Email = TokenArray[1];
            if (String.IsNullOrEmpty(token))
            {
                context.ErrorResult = new AuthenticationFaliurResult("Missing Token", request);
                return;
            }
            string ValidEmail = TokenManager.ValidateToken(token);
            if (ValidEmail != Email)
            {
                context.ErrorResult = new AuthenticationFaliurResult("Invalid Token For Email", request);
                return;
            }
            context.Principal = TokenManager.GetPrincipal(token);
        }

        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            var result = await context.Result.ExecuteAsync(cancellationToken);
            if (result.StatusCode == HttpStatusCode.Unauthorized)
            {
                result.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue("Basic", "realm=localhost"));
            }
            context.Result = new ResponseMessageResult(result);
        }
    }

    public class AuthenticationFaliurResult : IHttpActionResult
    {
        public string ReasonPharse;
        public HttpRequestMessage Request { get; set; }

        public AuthenticationFaliurResult(string reasonPharse, HttpRequestMessage request)
        {
            ReasonPharse = reasonPharse;
            Request = request;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }

        public HttpResponseMessage Execute()
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            responseMessage.RequestMessage = Request;
            responseMessage.ReasonPhrase = ReasonPharse;
            return responseMessage;
        }

    }
}