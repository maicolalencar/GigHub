using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers
{
    public class AttendencesController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendencesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Attend(AttendenceDto attendenceDto)
        {
            var userId = User.Identity.GetUserId();
            if (_context.Attendances.Any(a => a.GigId == attendenceDto.GigId && a.AttendeeId == userId))
                return BadRequest("Comparecimento já estava confirmado");

            var attendance = new Attendance() { AttendeeId = userId, GigId = attendenceDto.GigId };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok("");
        }
    }
}
