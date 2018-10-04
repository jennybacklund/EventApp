using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventApp.Data;
using EventApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EventApp.Controllers
{
    public class ParticipantsController : Controller
    {
        private EventAppContext db;
        private UserManager<AppUser> userManager;

        public ParticipantsController(EventAppContext db, UserManager<AppUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public IActionResult Participate(Participant participant)
        {
            participant.UserId = userManager.GetUserName(User);

            db.Participants.Add(participant);
            db.SaveChanges();

            return RedirectToAction("Details", "Events", new {id = participant.EventId });
        }
    }
}