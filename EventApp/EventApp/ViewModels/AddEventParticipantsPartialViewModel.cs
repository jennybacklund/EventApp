using EventApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventApp.ViewModels
{
    public class AddEventParticipantsPartialViewModel
    {
        public Event Event { get; set; }
        public Participant Participant { get; set; }
        public AppUser AppUser { get; set; }

        public AddEventParticipantsPartialViewModel(Event myEvent)
        {
            Event = myEvent;
        }
    }
}
