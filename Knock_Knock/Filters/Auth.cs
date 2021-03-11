using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Net;
using Knock_Knock.Models.AuthenticationEncryptionLayer;

namespace Knock_Knock.Filters
{
    public class Auth:ActionFilterAttribute
    {
        public string role { get; set; }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //if there's not token header return unauthorized
            if (!actionContext.Request.Headers.Contains("x-auth-token"))
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                return;
            }

            string token = actionContext.Request.Headers.GetValues("x-auth-token").First();
            EncryptionDecryption ed = new EncryptionDecryption();
            bool validation = ed.validateToken(token);

            //if token is invalid return unauthorized
            if (!validation)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                return;
            }

            if (role!=null && !role.Equals(ed.getRole(token)))
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                return;
            }
            
        }
    }
}