using GigHub.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {

            var listGigs = _context.Gigs.Include(g => g.Artist).Where(g => g.DateTime > DateTime.Now).OrderBy(g => g.DateTime);
            return View(listGigs);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}