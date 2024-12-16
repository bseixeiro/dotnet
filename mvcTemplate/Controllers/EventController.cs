using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvc.Data;
using mvc.Models.Event;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Event/Index
        public IActionResult Index()
        {
            var events = _context.Events.ToList();
            return View(events);
        }

        // GET: Event/Create
        [Authorize(Roles = "Teacher")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        [Authorize(Roles = "Teacher")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var @event = new Event
                {
                    Title = model.Title,
                    Description = model.Description,
                    EventDate = model.EventDate,
                    MaxParticipants = model.MaxParticipants,
                    Location = model.Location
                };

                _context.Events.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Event/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var @event = await _context.Events.FindAsync(id);

            if (@event == null)
                return NotFound();

            var viewModel = new DetailsViewModel
            {
                Id = @event.Id,
                Title = @event.Title,
                Description = @event.Description,
                EventDate = @event.EventDate,
                MaxParticipants = @event.MaxParticipants,
                Location = @event.Location,
                CreatedAt = @event.CreatedAt
            };

            return View(viewModel);
        }

        // GET: Event/Edit/5
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Edit(int id)
        {
            var @event = await _context.Events.FindAsync(id);

            if (@event == null)
                return NotFound();

            var viewModel = new EditViewModel
            {
                Id = @event.Id,
                Title = @event.Title,
                Description = @event.Description,
                EventDate = @event.EventDate,
                MaxParticipants = @event.MaxParticipants,
                Location = @event.Location
            };

            return View(viewModel);
        }

        // POST: Event/Edit/5
        [Authorize(Roles = "Teacher")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var @event = await _context.Events.FindAsync(model.Id);
                if (@event == null)
                    return NotFound();

                @event.Title = model.Title;
                @event.Description = model.Description;
                @event.EventDate = model.EventDate;
                @event.MaxParticipants = model.MaxParticipants;
                @event.Location = model.Location;

                _context.Update(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Event/Delete/5
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Delete(int id)
        {
            var @event = await _context.Events.FindAsync(id);

            if (@event == null)
                return NotFound();

            var viewModel = new DetailsViewModel
            {
                Id = @event.Id,
                Title = @event.Title,
                Description = @event.Description,
                EventDate = @event.EventDate,
                MaxParticipants = @event.MaxParticipants,
                Location = @event.Location,
                CreatedAt = @event.CreatedAt
            };

            return View(viewModel);
        }

        // POST: Event/Delete/5
        [Authorize(Roles = "Teacher")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Events.FindAsync(id);

            if (@event != null)
            {
                _context.Events.Remove(@event);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
