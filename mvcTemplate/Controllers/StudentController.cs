using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Models.Student;

namespace mvc.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<Student> _userManager; 


        // Constructeur 
        public StudentController(ApplicationDbContext context, UserManager<Student> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null && User.IsInRole("Student"))
                return RedirectToAction("Details", "Student", new { id = user.Id });

            var students = await _context.Students.ToListAsync();
            return View(students);
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Create()
        {
            return View();
        }


        // POST: Student/Create
        [Authorize(Roles = "Teacher")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new Student
            {
                UserName = model.Lastname + model.Firstname,
                Email = model.Email,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Age = model.Age,
                Major = model.Major,
                AdmissionDate = model.AdmissionDate,
                GPA = 0.0,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, ["Student"]);
                return RedirectToAction("Index", "Student");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        public async Task<IActionResult> Details(string id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            var viewModel = new DetailsViewModel
            {
                Id = student.Id,
                Firstname = student.Firstname,
                Lastname = student.Lastname,
                Age = student.Age,
                Major = student.Major,
                AdmissionDate = student.AdmissionDate,
                Email = student.Email,
                GPA = student.GPA
            };

            return View(viewModel);
        }

        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null) return NotFound();

            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            EditViewModel model = new EditViewModel()
            {
                Id = student.Id,
                Firstname = student.Firstname,
                Lastname = student.Lastname,
                Email = student.Email,
                Age = student.Age,
                Major = student.Major,
                AdmissionDate = student.AdmissionDate,
                GPA = student.GPA

            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Edit(string id, EditViewModel model)
        {
            if (id != model.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var student = await _userManager.FindByIdAsync(model.Id);
                    if (student == null) return NotFound();

                    student.Firstname = model.Firstname;
                    student.Lastname = model.Lastname;
                    student.Age = model.Age;
                    student.Major = model.Major;
                    student.AdmissionDate = model.AdmissionDate;
                    student.Email = model.Email;
                    student.GPA = model.GPA;
                    student.UserName = model.Lastname + model.Firstname;


                    var result = await _userManager.UpdateAsync(student);

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
                     throw;
                }

                return RedirectToAction("Index", "Student");
            }

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var student = await _context.Students.FindAsync(id);
            await _userManager.DeleteAsync(student);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null) return NotFound();

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null) return NotFound();

            return View(student);
        }

    }
}
