using PollApi.Models;
using System.Net;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using UserDataAccess;

namespace PollApi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(LoginRequest login)
        {

            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            UserDataEntities entities = new UserDataEntities();

            var user = entities.Users.FirstOrDefault(e => e.Username == login.Username && e.Password == login.Password);
            if (user != null)
            {
                var token = TokenGenerator.GenerateTokenJwt(login.Username);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
