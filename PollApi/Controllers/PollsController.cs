using OptionDataAccess;
using PollApi.Models;
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
        public IHttpActionResult Get()
        {
            PollDataEntities entities = new PollDataEntities();
            OptionDataEntities optionEntities = new OptionDataEntities();
            var polls = entities.Polls.ToList();
            List<Option> options = new List<Option>();
            foreach (var poll in polls)
            {
                var allOptions = optionEntities.Options.Where(o => o.PollID == poll.ID).ToList();
                foreach (var currentOption in allOptions)
                {
                    options.Add(currentOption);
                }
            }
            var model = new PollResponse { _pollDetails = polls, _optionDetails = options };
            return Ok(model);
        }


        [HttpGet]
        [Route("detail")]
        public IHttpActionResult Detail(int id)
        {
            PollDataEntities pollDataEntities = new PollDataEntities();
            OptionDataEntities optionEntities = new OptionDataEntities();
            List<Option> options = new List<Option>();
            var allOptions = optionEntities.Options.Where(o => o.PollID == id).ToList();
            var poll = pollDataEntities.Polls.Find(id);
            foreach (var currentOption in allOptions)
            {
                options.Add(currentOption);
            }
            var model = new PollDetailResponse { _pollDetail = poll, _optionDetails = options };
            return Ok(model);
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
