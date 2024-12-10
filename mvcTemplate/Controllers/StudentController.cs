using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers;

public class StudentController : Controller
{
    private static List<Student> students = new(){
            new Student(){name="Doe", firstname="John", age=40, startDate = new DateTime(2021, 9, 9)},
            new Student(){name="Seixeiro", firstname="Benjamin", age=20, startDate = new DateTime(2021, 9, 9)},
            new Student(){name="Merveilles", firstname="Alice", age=12, startDate = new DateTime(2021, 9, 9)}
    };
    public IActionResult Index()
    {
        return View(StudentController.students);
    }
}
