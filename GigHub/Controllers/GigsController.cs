using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        ApplicationDbContext _context;
        public GigsController()
        {
            _context = new ApplicationDbContext();
        }


        [Authorize]
        public ActionResult Create()
        {
            var gigsForm = new GigFormViewModel()
            {
                Genres = _context.Genres
            };
            return View(gigsForm);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(GigFormViewModel gigViewModel)
        {
            var gig = new Gig()
            {
                ApplicationUserId = User.Identity.GetUserId(),
                Venue = gigViewModel.Venue,
                DateTime = gigViewModel.DateTime,
                GenreId = gigViewModel.Genre
            };

            _context.Gigs.Add(gig);//TODO:memorizar
            _context.SaveChanges();

            return RedirectToAction("Home");

        }
    }
}