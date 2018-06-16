using Encamina.workshop.Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Encamina.workshop.Backend.Infraestructure.Entities
{
    public class EventRepository
    {
        private ConferenceContext context;

        public EventRepository(ConferenceContext dbcontext)
        {
            context = dbcontext;
        }
         
        public List<Event> Get()
        {
            if (context.Event.Any())
            {
                return context.Event.ToList();
            }
            return null;
        }

        public Event Get(int Id)
        {
            if (context.Event.Any())
            {
                var result = context.Event.Where(e => e.ID == Id).Include(s => s.Sessions).FirstOrDefault();
                return result;
            }
            return null;
        }

        public int Insert(Event Event)
        {
            context.Event.Add(Event);
            var result =context.SaveChanges();
            return Event.ID;
        }

        public void Update(Event Event)
        {
            context.Event.Update(Event);
            context.SaveChanges();
        }
    }
}
