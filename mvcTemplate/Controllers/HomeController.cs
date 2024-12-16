using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// une directive qui permet d'importer les classes du namespace mvc.Models
using mvc.Models;

namespace mvc.Controllers;
[AllowAnonymous]
public class HomeController : Controller
{

    private readonly UserManager<Account> _userManager;
    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger, UserManager<Account> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);

        if (user != null )
        {
            return RedirectToAction("Details", "Home");
        }
        return View();
    }

    [Authorize]
    public async Task<IActionResult> Details()
    {
        var user = await _userManager.GetUserAsync(User);

       DetailsViewModel model = new DetailsViewModel()
       {
           Lastname = user.Lastname,
           Firstname = user.Firstname,
           Age = user.Age,
           Email = user.Email
       };

        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        Console.WriteLine("Error");
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
