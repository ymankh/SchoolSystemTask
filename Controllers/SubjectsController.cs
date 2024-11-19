using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolSystemTask.Models;
using SchoolSystemTask.Repositories;

namespace SchoolSystemTask.Controllers
{
    public class SubjectsController(ClassesRepository classesRepository, MyDbContext context) : Controller
    {
        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            var user = GetUser()!;
            var subjects = classesRepository.GetClasses(user.TeacherId).Subjects;
            return View(subjects);
        }

        private UserTeacher? GetUser()
        {
            var id = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var user = context.UserTeachers.Find(id);
            return user;
        }
    }
}