using Microsoft.AspNetCore.Mvc;
using SchoolSystemTask.Models;
using SchoolSystemTask.ViewModels;
using System.Diagnostics;
using SchoolSystemTask.Models.SchoolManagementSystem.Data;

namespace SchoolSystemTask.Controllers
{
    public class HomeController(ILogger<HomeController> logger, MyDbContext context) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;

        public IActionResult Index()
        {
            // Authorization 
            var userId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            var user = context.UserTeachers.Find(userId);

            if (user == null)
                return RedirectToAction(nameof(HomePage));
            var students = context.Students.ToList();
            var data = new HomeViewModel
            {
                Students = students
            };
            return View(data);
        }

        public IActionResult HomePage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginPage([FromForm] string email, [FromForm] string password)
        {
            var user = context.UserTeachers.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user == null) return View();
            ViewBag.Message = "Bad credentials";
            HttpContext.Session.SetString("UserId", user.UserTeacherId.ToString());
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(HomePage));
        }
        public IActionResult RegisterPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterPage([FromForm] string firstName, [FromForm] string lastName, [FromForm] string password, [FromForm] string email)
        {
            var oldUser = context.UserTeachers.FirstOrDefault(u => u.Email == email);
            if (oldUser != null)
            {
                ViewBag.Message = "There is already an existing account associated with an existing account.";
                return View();
            }

            var newTeacher = new Teacher
            {
                FirstName = firstName,
                LastName = lastName
            };
            context.Teachers.Add(newTeacher);
            context.SaveChanges();
            var newUser = new UserTeacher
            {
                Email = email,
                Password = password,
                TeacherId = newTeacher.TeacherId
            };
            context.UserTeachers.Add(newUser);
            context.SaveChanges();
            return Redirect(nameof(LoginPage));
        }

        public IActionResult Students()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Students([FromForm] string firstName, [FromForm] string lastName, [FromForm] int classId)
        {
            var student = new Student
            {
                FirstName = firstName,
                LastName = lastName,
                ClassId = classId
            };
            context.Students.Add(student);
            context.SaveChanges();
            ViewBag.Message = "Student has been added successfully";

            return View();
        }

        public IActionResult Exams()
        {
            return View();
        }
        public IActionResult Classes()
        {
            return View();
        }
        public IActionResult Chat()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
