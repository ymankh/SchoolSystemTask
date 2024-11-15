using Microsoft.AspNetCore.Mvc;

namespace SchoolSystemTask.Controllers;

public class StudentController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}