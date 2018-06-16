using Encamina.workshop.Backend;
using Encamina.workshop.Backend.Infraestructure.Entities;
using Encamina.workshop.Backend.Models;
using System;
using System.Collections.Generic;

namespace Encamina.workshop.Services
{

    public class ConferenceService
    {
        private ConferenceContext context;
        public ConferenceService(ConferenceContext dbContext)
        {
            context = dbContext;
        }

        #region Events
        public int AddConference(Event Event)
        {
            EventRepository repository = new EventRepository(context);
            return repository.Insert(Event);
        }

        public List<Event> GetEvents()
        {
            EventRepository repository = new EventRepository(context);
            return repository.Get();
        }

        public Event GetEventById(int Id)
        {
            EventRepository repository = new EventRepository(context);
            return repository.Get(Id);
        }

        public void UpdateEvent(Event Event)
        {
            EventRepository repository = new EventRepository(context);
            repository.Update(Event);
        }
        #endregion Events
    }
}
