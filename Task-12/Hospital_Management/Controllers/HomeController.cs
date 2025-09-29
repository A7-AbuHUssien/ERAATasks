using Microsoft.AspNetCore.Mvc;

namespace DoctorManagementSystem.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
