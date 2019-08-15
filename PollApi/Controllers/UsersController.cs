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
        [Route("all")]
        public IEnumerable<User> Get()
        {
            using (UserDataEntities entities = new UserDataEntities())
            {
                return entities.Users.ToList();
            }
        }

        [HttpPost]
        [Route("register")]
        public IHttpActionResult Add(User user)
        {
            if (user != null)
            {
                UserDataEntities entities = new UserDataEntities();
                var response = entities.Users.Add(user);
                entities.SaveChanges();
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("remove")]
        public IHttpActionResult Remove(User user)
        {
            if (user != null)
            {
                UserDataEntities entities = new UserDataEntities();
                var pollToRemove = entities.Users.Find(user.ID);
                entities.Users.Remove(pollToRemove);
                return Ok("Record deleted");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
