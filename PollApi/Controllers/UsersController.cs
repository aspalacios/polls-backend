using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using System.Web.Http.Cors;
using UserDataAccess;

namespace PollApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/users")]
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("users")]
        public IEnumerable<User> Get()
        {
            using (UserDataEntities entities = new UserDataEntities())
            {
                return entities.Users.ToList();
            }
        }
    }
}
