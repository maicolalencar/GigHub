using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.API
{
    public class GigController : ApiController
    {
        ApplicationDbContext _context;

        public GigController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Authorize]
        public IHttpActionResult Cancel(int id)
        {

            var UserId = User.Identity.GetUserId();
            _context.Gigs.Single(g => g.Id == id && g.Artist.Id == UserId).IsCanceled = true;
            _context.SaveChanges();

            return Ok();


        }
    }
}