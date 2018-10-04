using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventApp.Data;
using EventApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventApp.Controllers
{
    public class EventsController : Controller
    {
        private EventAppContext db;

        public EventsController(EventAppContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            List<Event> model = db.Events.ToList();

            return View(model);
        }

        public IActionResult Details(int id)
        {
            Event model = db.Events
                .Where(e => e.Id == id)
                .Include(e => e.Participants)
                .FirstOrDefault();

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Event myEvent)
        {
            db.Events.Add(myEvent);

            db.SaveChanges();

            return RedirectToAction("MinSida", "Home");
        }
    }
}