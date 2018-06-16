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

            var @event = await _context.Event
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
            var @event = await _context.Event.SingleOrDefaultAsync(m => m.ID == id);
            _context.Event.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.ID == id);
        }
    }
}
