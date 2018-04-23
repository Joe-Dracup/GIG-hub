using GigHub.Models;
using System;
using System.Linq;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using GigHub.Dtos;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upComingGigs = _context.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .Where(g => g.DateTime > DateTime.Now);
            return View(upComingGigs);
        }

        public ActionResult Artists()
        {
            var availableArtists = _context.Users
                .Where(u => u.IsArtist);
            return View(availableArtists);
        }

        private IHttpActionResult BadRequest(string v)
        {
            throw new NotImplementedException();
        }
    }
}