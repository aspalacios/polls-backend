using OptionDataAccess;
using System.Web.Http;

namespace PollApi.Controllers
{
    public class OptionsController : ApiController
    {
        [HttpPost]
        [Route("add")]
        public IHttpActionResult Add(Option option)
        {
            if (option != null)
            {
                OptionDataEntities entities = new OptionDataEntities();
                var response = entities.Options.Add(option);
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
        public IHttpActionResult Remove(Option poll)
        {
            if (poll != null)
            {
                OptionDataEntities entities = new OptionDataEntities();
                var optionToRemove = entities.Options.Find(poll.ID);
                entities.Options.Remove(optionToRemove);
                return Ok("Record deleted");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
