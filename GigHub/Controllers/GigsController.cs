using GigHub.Models;
using GigHub.ViewModels;
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

        public ActionResult Create()
        {
            var gigsForm = new GigFormViewModel()
            {
                Genres = _context.Genres
            };
            return View(gigsForm);
        }
    }
}