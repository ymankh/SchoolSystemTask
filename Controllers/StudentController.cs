using Microsoft.AspNetCore.Mvc;

namespace SchoolSystemTask.Controllers;

public class StudentController : Controller
{
    public IActionResult HomePage()
    {
        return View();
    }
}