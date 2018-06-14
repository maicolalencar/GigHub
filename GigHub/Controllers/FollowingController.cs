using GigHub.Dtos;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Models
{
    public class FollowingController : ApiController
    {

        public ApplicationDbContext _context;

        public FollowingController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_context.Followings.Any(a => a.FollowerId == userId && a.FolloweeId == followingDto.FolloweeId))
                return BadRequest("Following already exists.");

            var following = new Following()
            {
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeId
            };
            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok("");
        }
    }
}
