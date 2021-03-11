using System.Web.Http;
using Knock_Knock.Entities;
using Knock_Knock.Models.AuthenticationEncryptionLayer;
using Knock_Knock.Filters;
using System.Net.Http;
using System.Net;

namespace Knock_Knock.Controllers
{
    public class AuthenticationController : ApiController
    {

        [HttpPost]
        [Route("api/register")]
        public IHttpActionResult register([FromBody]User user)
        {

            Authentication auth = new Authentication();
            string token=auth.registerUser(user);
            if (token == "alreadyExist" || token == "error") return BadRequest(token);
            return Ok(token);
        }

        [HttpPost]
        [Route("api/login")]
        public IHttpActionResult login([FromBody]User user)
        {
            Authentication auth = new Authentication();
            string token = auth.loginUser(user);
            if (token == "wrong credentials") return BadRequest(token);
            return Ok(token);
        }
    }
}