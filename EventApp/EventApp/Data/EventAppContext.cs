using EventApp.Models;
using EventApp.RequestObjects;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventApp.Data
{
    public class EventAppContext : IdentityDbContext<AppUser>
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Participant> Participants { get; set; }

        public EventAppContext(DbContextOptions<EventAppContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>().HasData(SeedData.Events);
        }
    }
}
