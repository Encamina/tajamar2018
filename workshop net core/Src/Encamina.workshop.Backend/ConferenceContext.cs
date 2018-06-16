using Encamina.workshop.Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Encamina.workshop.Backend
{
    public class ConferenceContext : DbContext
    {
        public DbSet<Event> Event { get; set; }
        public DbSet<Session> Session { get; set; }
        public DbSet<Speaker> Speaker { get; set; }

        public ConferenceContext(DbContextOptions<ConferenceContext> options) : base(options)
        {

        }
    }
}
