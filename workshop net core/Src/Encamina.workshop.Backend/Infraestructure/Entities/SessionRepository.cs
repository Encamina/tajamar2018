using Encamina.workshop.Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Encamina.workshop.Backend.Infraestructure
{
    public class SessionRepository
    {

        private ConferenceContext context;

        public SessionRepository(ConferenceContext dbcontext)
        {
            context = dbcontext;
        }

        public List<Session> Get()
        {
            if (context.Session.Any())
            {
                return context.Session.ToList();
            }
            return null;
        }

        public Session Get(int Id)
        {
            if (context.Session.Any())
            {
                return context.Session.Where(e => e.ID == Id).Include(s => s.Speaker).FirstOrDefault();
            }
            return null;
        }

        public int Insert(Session Event)
        {
            context.Session.Add(Event);
            var result = context.SaveChanges();
            return Event.ID;
        }

        public void Update(Session Event)
        {
            context.Session.Update(Event);
            context.SaveChanges();
        }
    }
}
