using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EventApp.Models
{
    public class AppUser : IdentityUser
    {
        public virtual List<Participant> Participants { get; set; }
    }
}
