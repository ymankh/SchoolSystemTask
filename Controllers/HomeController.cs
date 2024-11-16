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
using SchoolSystemTask.DTOs.StudentNoteDTOs;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

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
        ExamsRepository examsRepository,
        StudentNoteRepository studentNoteRepository,
        NoteTypesRepository noteTypesRepository
    ) : Controller
    {
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
        public IActionResult RegisterPage([FromForm] string firstName, [FromForm] string lastName,
            [FromForm] string password, [FromForm] string email)
        {
            // Check if email has a user
            var oldUser = userRepository.GetUserByEmail(email);
            if (oldUser != null)
            {
                ViewBag.Message = "There is already an existing account associated with an existing account.";
                return View();
            }

            var newTeacher = teacherRepository.CreateTeacher(firstName, lastName);
            userRepository.Register(newTeacher, email, password, "teacher");
            return Redirect(nameof(LoginPage));
        }

        public IActionResult Students()
        {
            var data = new StudentsViewModel
            {
                Students = studentsRepository.All(),
                Classes = classesRepository.GetClasses().Classes,
                NoteTypes = noteTypesRepository.GetNoteTypes()
            };
            return View(data);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddStudentNote(CreateStudentNoteDto newNote)
        {
            var user = GetUser();
            studentNoteRepository.AddStudentNote(newNote, user!.TeacherId);
            return Redirect(nameof(Students));
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
            if (user == null)
            {
                return RedirectToAction(nameof(HomePage));
            }

            var data = new ExamViewModel
            {
                Classes = classesRepository.GetClasses(user.TeacherId),
                Exams = examsRepository.TeacherExams(user.TeacherId)
            };
            return View(data);
        }

        // For Adding an Exam 
        [HttpPost]
        public IActionResult Exams([FromForm] CreateExamDto createExamDto)
        {
            var user = GetUser();
            examsRepository.AddExam(createExamDto);
            return Redirect(nameof(Exams));
        }

        [HttpDelete("DeleteExam/{id:int}")]
        public IActionResult DeleteExam(int id)
        {
            var user = GetUser();
            examsRepository.DeleteExam(id);
            return Redirect(nameof(Exams));
        }

        [Authorize]
        public IActionResult Classes()
        {
            var user = GetUser();
            var classes = classesRepository.GetClasses(user!.TeacherId);

            return View(classes);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Classes([FromForm] AddClassDto addClassDto)
        {
            var user = GetUser();
            classesRepository.CreateClass(addClassDto, user!.TeacherId);
            return Redirect(nameof(Classes));
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddSubject([FromForm] AddSubjectToClassDto addSubjectDto)
        {
            var user = GetUser();
            classesRepository.CreateSubject(addSubjectDto, user!.TeacherId);
            return Redirect(nameof(Classes));
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

        [Authorize]
        [HttpGet("Home/ExamMarks/{examId:int}")]
        public IActionResult ExamMarks([FromRoute] int examId)
        {
            var user = GetUser()!;
            var examMarks = examsRepository.GetExamMarks(examId, user.TeacherId);
            return View(examMarks);
        }

        [Authorize]
        [HttpPost("Home/ExamMarks/{examId:int}")]
        public IActionResult ExamMarks([FromRoute] int examId, [FromForm] string[] examWithMark)
        {
            examsRepository.UpdateExamMarks(examWithMark);
            return Redirect(nameof(ExamMarks));
        }

        [Authorize]
        [HttpGet]
        public IActionResult StudentNote()
        {
            var user = GetUser();
            var data = new StudentNoteViewModel
            {
                StudentNotes = studentNoteRepository.GetTeacherStudentNotes(user!.TeacherId),
                NoteTypes = studentNoteRepository.GetNoteTypes()
            };
            return View(data);
        }

        [Authorize]
        [HttpPost]
        public IActionResult EditStudentNote(EditStudentNoteDto editStudentNoteDto)
        {
            studentNoteRepository.EditNote(editStudentNoteDto);
            return Redirect(nameof(StudentNote));
        }
    }
}