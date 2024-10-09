using Microsoft.AspNetCore.Mvc;
using SchoolSystemTask.Models;
using SchoolSystemTask.ViewModels;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using SchoolSystemTask.Helpers;
using SchoolSystemTask.Repositories;
using Microsoft.AspNetCore.Authorization;
using SchoolSystemTask.DTOs.ClassesDTOs;
using SchoolSystemTask.DTOs.StudentsDTOs;
using SchoolSystemTask.DTOs.ExamDTOs;

namespace SchoolSystemTask.Controllers
{
    public class HomeController(
    ILogger<HomeController> logger,
    MyDbContext context,
    // Repositories
    UserRepository userRepository,
    TeacherRepository teacherRepository,
    ClassesRepository classesRepository,
    StudentsRepository studentsRepository,
    ExamsRepository examsRepository
    ) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;

        [Authorize]
        public IActionResult Index()
        {
            var students = studentsRepository.All();
            var data = new HomeViewModel
            {
                Students = students,
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
        public async Task<IActionResult> LoginPage([FromForm] string email, [FromForm] string password)
        {
            var user = userRepository.GetUserByEmailAndPassword(email, password);
            if (user == null)
            {
                ViewBag.Email = email;
                ViewBag.Message = "Bad credentials";
                return View();
            }
            // Create claims based on user data
            var claims = new List<Claim>
            {
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.NameIdentifier, user.UserTeacherId.ToString()),
                new(ClaimTypes.Role, "User") // Assign role to the user claim
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = false // Cookie is not persistent across sessions
            };

            // Sign in the user and issue the cookie
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authProperties);

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("HomePage", "Home");
        }

        public IActionResult RegisterPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterPage([FromForm] string firstName, [FromForm] string lastName, [FromForm] string password, [FromForm] string email)
        {
            // Check if email has a user
            var oldUser = userRepository.GetUserByEmail(email);
            if (oldUser != null)
            {
                ViewBag.Message = "There is already an existing account associated with an existing account.";
                return View();
            }

            var newTeacher = teacherRepository.CreateTeacher(firstName, lastName);
            var newUser = userRepository.Register(newTeacher, email, password, "teacher");
            return Redirect(nameof(LoginPage));
        }

        public IActionResult Students()
        {
            var data = new StudentsViewModel
            {
                Students = studentsRepository.All(),
                Classes = classesRepository.GetClasses().Classes
            };
            var students = studentsRepository.All();
            return View(data);
        }

        [HttpPost]
        public IActionResult Students([FromForm] AddStudentDto addStudentDto)
        {
            studentsRepository.Add(addStudentDto);
            ViewBag.Message = "Student has been added successfully";

            return Redirect(nameof(Students));
        }
        [Authorize]
        public IActionResult Exams()
        {
            var user = GetUser();
            var data = new ExamViewModel
            {
                Classes = classesRepository.GetClasses(user.TeacherId),
                Exams = examsRepository.TeacherExams(user.TeacherId)
            };
            return View();
        }

        // For Adding an Exam 
        [HttpPost]
        public IActionResult Exams([FromForm] CreateExamDto createExamDto)
        {

            return Redirect(nameof(Exam));
        }
        [Authorize]
        public IActionResult Classes()
        {
            var user = GetUser();
            var classes = classesRepository.GetClasses();
            return View(classes);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Classes([FromForm] AddClassDto addClassDto)
        {
            var user = GetUser();
            var newClass = classesRepository.CreateClass(addClassDto, user!.TeacherId);
            var classes = classesRepository.GetClasses();
            return View(classes);
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
        // Only use after authentication
        private UserTeacher? GetUser()
        {
            var id = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var user = context.UserTeachers.Find(id);
            return user;
        }
    }
}
