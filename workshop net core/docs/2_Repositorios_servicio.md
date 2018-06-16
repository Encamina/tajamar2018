
## Arreglar el estropicio de scaffold

> 1. Como podemos ver,al auto-generar los controller, estos tienen una complejidad extra ya que tanto la consultas como la lógica esta en estos
> 2. Vamos a crear un modelo repositorio para que las consultas se definan en la capa de datos
> 3. Vamos a crear una clase de dominio que conlleve la lógica de negocio necesaria para la aplicación
> 4. Con todo esto el controller queda mucho más sencillo y no encapsulamos en la capa de presentación

## Clase Repositorios - Event,Sessión,Speaker

1. Creamos en el proyecto de backend, una carpeta 'infraestructure/entities'
2. Añadimos las clases repositorio
3. Clase `EventRepository.cs`.

```csharp
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
            if (context.Events.Any())
            {
                return context.Events.ToList();
            }
            return null;
        }

        public Event Get(int Id)
        {
            if (context.Events.Any())
            {
                var result = context.Events.Where(e => e.ID == Id).Include(s => s.Sessions).FirstOrDefault();
                return result;
            }
            return null;
        }

        public int Insert(Event Event)
        {
            context.Events.Add(Event);
            var result =context.SaveChanges();
            return Event.ID;
        }

        public void Update(Event Event)
        {
            context.Events.Update(Event);
            context.SaveChanges();
        }
    }
}

```
4. Clase `SessionRepository.cs`

```csharp
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
            if (context.Sessions.Any())
            {
                return context.Sessions.ToList();
            }
            return null;
        }

        public Session Get(int Id)
        {
            if (context.Sessions.Any())
            {
                return context.Sessions.Where(e => e.ID == Id).Include(s => s.Speaker).FirstOrDefault();
            }
            return null;
        }

        public int Insert(Session Event)
        {
            context.Sessions.Add(Event);
            var result = context.SaveChanges();
            return Event.ID;
        }

        public void Update(Session Event)
        {
            context.Sessions.Update(Event);
            context.SaveChanges();
        }
    }
}

```

5  Clase `SpeakerRepository.cs`

```csharp
using Encamina.workshop.Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Encamina.workshop.Backend.Infraestructure.Entities
{
    public class SpeakerRepository
    {
        private ConferenceContext context;

        public SpeakerRepository(ConferenceContext dbcontext)
        {
            context = dbcontext;
        }

        public List<Speaker> Get()
        {
            if (context.Speakers.Any())
            {
                return context.Speakers.ToList();
            }
            return null;
        }

        public Speaker Get(int Id)
        {
            if (context.Speakers.Any())
            {
                return context.Speakers.Where(e => e.ID == Id).Include(s => s.Sessions).FirstOrDefault();
            }
            return null;
        }

        public int Insert(Speaker Event)
        {
            context.Speakers.Add(Event);
            var result = context.SaveChanges();
            return Event.ID;
        }

        public void Update(Speaker Event)
        {
            context.Speakers.Update(Event);
            context.SaveChanges();
        }
    }
}

```

## Capa de Domain - Services
1. Creamos un nuevo proyecto de Clases en la carpeta Service, le llamaremos `NombreAlumno.workshop.services`
2. Creamos una clase `ConferenceService` con el siguiente código

```csharp
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

```
3. El código solo lleva la parte de Events, el resto queda por hacer como práctica

## Adaptar el controller de Events con los nuevos servicios

1. Modificamos el controller de Event con este código

```charp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Encamina.workshop.Backend;
using Encamina.workshop.Backend.Models;
using Encamina.workshop.Backend.Infraestructure.Entities;

namespace Encamina.workshop.ConferenceWeb.Controllers
{
    public class EventController : Controller
    {
        private readonly ConferenceContext _context;
        private EventRepository repository;

        public EventController(ConferenceContext context)
        {
            _context = context;
            repository = new EventRepository(_context);
        }

        // GET: Event
        public IActionResult Index()
        {
            return  View(repository.Get());
        }

        // GET: Event/Details/5
        public IActionResult Details(int id)
        {
            var Event = repository.Get(id);
            return View(Event);
        }

        // GET: Event/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,DateEvent,Organizer,ID")] Event @event)
        {
            if (ModelState.IsValid)
            {
                var result = repository.Insert(@event);
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        // GET: Event/Edit/5
        public IActionResult Edit(int id)
        {
            var @event = repository.Get(id);
            repository.Update(@event);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Name,DateEvent,Organizer,ID")] Event @event)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    repository.Update(@event);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                        return NotFound();
                  
                }
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        // GET: Event/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .SingleOrDefaultAsync(m => m.ID == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Events.SingleOrDefaultAsync(m => m.ID == id);
            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.ID == id);
        }
    }
}

```
2. Quedaría pendiente de migrar el resto de vistas, y añadir las operaciones de borrado
3. Por ultimo retocar los estilos de todas las vistas y adaptarlas al gusto

