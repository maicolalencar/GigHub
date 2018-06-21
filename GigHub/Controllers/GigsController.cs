using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
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
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var gigs =
                _context.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .Where(g => g.Artist.Id == userId && g.DateTime > DateTime.Now)
                .OrderBy(g => g.DateTime)
                .ToList();

            return View(gigs);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = _context.Gigs.FirstOrDefault(g => g.Id == id && g.Artist.Id == userId);

            var gigsForm = new GigFormViewModel()
            {
                Id = gig.Id,
                Heading = "Edit a Gig",
                Venue = gig.Venue,
                Date = gig.DateTime.ToString("dd/MM/yyyy"),
                Time = gig.DateTime.ToString("HH:mm"),
                Genres = _context.Genres,
                Genre = gig.GenreId,


            };
            return View("GigForm", gigsForm);
        }

        [Authorize]
        public ActionResult Create()
        {
            var gigsForm = new GigFormViewModel()
            {
                Heading = "Add a Gig",
                Genres = _context.Genres
            };
            return View("GigForm", gigsForm);
        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var viewModel = new GigsViewModel
            {
                upcomingGigs = _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(g => g.Gig)
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .ToList(),

                showActions = true,
                Heading = "Gigs I'm going"
            };

            return View("Gigs", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel gigViewModel)
        {
            if (!ModelState.IsValid)
            {
                gigViewModel.Genres = _context.Genres;
                return View(gigViewModel);
            }
            var gig = new Gig()
            {
                ApplicationUserId = User.Identity.GetUserId(),
                Venue = gigViewModel.Venue,
                DateTime = gigViewModel.GetDateTime(),
                GenreId = gigViewModel.Genre
            };

            _context.Gigs.Add(gig);//TODO:memorizar
            _context.SaveChanges();

            return RedirectToAction("Mine");

        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(GigFormViewModel gigViewModel)
        {
            if (!ModelState.IsValid)
            {
                gigViewModel.Genres = _context.Genres;
                return View(gigViewModel);
            }
            var userId = User.Identity.GetUserId();

            var gig = _context.Gigs.Single(g => g.Artist.Id == userId && g.Id == gigViewModel.Id);

            gig.ApplicationUserId = User.Identity.GetUserId();
            gig.Venue = gigViewModel.Venue;
            gig.DateTime = gigViewModel.GetDateTime();
            gig.GenreId = gigViewModel.Genre;

            //_context.Gigs. (gig);//TODO:memorizar
            _context.SaveChanges();

            return RedirectToAction("Mine");

        }
    }
}