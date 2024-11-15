using Microsoft.AspNetCore.Mvc;

namespace SchoolSystemTask.Controllers;

public class StudentController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}