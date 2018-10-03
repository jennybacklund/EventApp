using EventApp.Models;
using EventApp.RequestObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventApp.Data
{
    public class SeedData
    {
        public static Event[] Events = {
            new Event {
                Id = 1,
                Title = "CosplayParty",
                ImageUrl = "https://placehold.it/500?text=Cosplay",
                Place = "Globen",
                Time = new DateTime(2018, 10, 20, 16, 0, 0),
                Description = "För alla cosplayälskare!",
            },
            new Event {
                Id = 2,
                Title = "TårtKalaset",
                ImageUrl = "https://placehold.it/500?text=Tårta",
                Place = "Teatern",
                Time = new DateTime(2018, 12, 08, 14, 30, 0),
                Description = "Om du älskar tårta!",
            },
        };
    }
}
