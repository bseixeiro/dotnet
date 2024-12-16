using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Models.Teacher;

namespace mvc.Controllers
{
    [Authorize(Roles ="Teacher")]
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Teacher> _userManager;

        // Constructeur 
        public TeacherController(ApplicationDbContext context, UserManager<Teacher> userManager)
        {
            _context = context;
            _userManager = userManager;
        }   

        // GET: Teachers/Add
        public IActionResult Add()
        {
            return View();
        }


        // POST: Teachers/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new Teacher
            {
                UserName = model.Lastname + model.Firstname,
                Email = model.Email,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Age = model.Age,
                Major = model.Major,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, ["Teacher"]);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        // GET: Teachers/Delete/Id
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null) return NotFound();

            var teacher = await _context.Teachers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacher == null) return NotFound();

            return View(teacher);
        }

        // POST: Teachers/Delete/Id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            await _userManager.DeleteAsync(teacher);
            return RedirectToAction(nameof(Index));
        }

        // GET: Teachers/Edit/Id
        public async Task<IActionResult> Edit(string? id)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (id != currentUser.Id)
            {
                return Forbid();
            }

            if (id == null) return NotFound();

            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null) return NotFound();

            EditViewModel model = new EditViewModel()
            {
                Id = teacher.Id,
                Firstname = teacher.Firstname,
                Lastname = teacher.Lastname,
                Email = teacher.Email,
                Age = teacher.Age,
                Major = teacher.Major,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(string id, EditViewModel model)
        {
            if (id != model.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var teacher = await _userManager.FindByIdAsync(model.Id);
                    if (teacher == null) return NotFound();

                    teacher.Lastname = model.Lastname;
                    teacher.Firstname = model.Firstname;
                    teacher.Email = model.Email;
                    teacher.Major = model.Major;
                    teacher.Age = model.Age;
                    teacher.UserName = model.Lastname + model.Firstname;

                    var result = await _userManager.UpdateAsync(teacher);

                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                        return View(model);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(model.Id)) return NotFound();
                    else throw;
                }

                return RedirectToAction("Index", "Teacher");
            }

            return View(model);
        }


        private bool TeacherExists(string id)
        {
            return _context.Teachers.Any(e => e.Id == id);
        }

        // Get teachers
        public async Task<ActionResult> Index()
        {
            return View(await _context.Teachers.ToListAsync());
        }

    }
}
