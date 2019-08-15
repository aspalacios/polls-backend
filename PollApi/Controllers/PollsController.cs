using PollDataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PollApi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/polls")]
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class PollsController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public IEnumerable<Poll> Get()
        {
            using (PollDataEntities entities = new PollDataEntities())
            {
                return entities.Polls.ToList();
            }
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult Add(Poll poll)
        {
            if (poll != null)
            {
                PollDataEntities entities = new PollDataEntities();
                var response = entities.Polls.Add(poll);
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
        public IHttpActionResult Remove(Poll poll)
        {
            if (poll != null)
            {
                PollDataEntities entities = new PollDataEntities();
                var pollToRemove = entities.Polls.Find(poll.ID);
                entities.Polls.Remove(pollToRemove);
                return Ok("Record deleted");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
