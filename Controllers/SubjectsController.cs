using Microsoft.AspNetCore.Mvc;
using SchoolSystemTask.Models;
using SchoolSystemTask.Repositories;

namespace SchoolSystemTask.Controllers
{
    public class SubjectsController(ClassesRepository classesRepository) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var subjects = classesRepository.GetClasses().Subjects;
            return View(subjects);
        }
    }
}