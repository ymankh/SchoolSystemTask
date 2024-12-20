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
using SchoolSystemTask.DTOs.Filters;
using SchoolSystemTask.DTOs.TeacherDTOs;

namespace SchoolSystemTask.Controllers;

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
    AssignmentSubmissionRepository assignmentSubmissionRepository,
    ActionHistoryRepository actionHistoryRepository
    ) : Controller
{
    [Authorize]
    public IActionResult Index()
    {
        var user = GetUser();
        if (user == null)
            return RedirectToAction(nameof(HomePage));

        var students = studentsRepository.TeacherStudents(user.TeacherId);
        var data = new HomeViewModel
        {
            Students = students,
            StudentNotes = studentNoteRepository.GetTeacherStudentNotes(user.TeacherId),
            AbsencesCount = students.Count(s => s.StudentAbsences.Any(a => a.DateTime.Date == DateTime.Today)),
            AssignmentCount = assignmentSubmissionRepository.SubmissionsCount(user.TeacherId)
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

    [Authorize]
    [HttpGet]
    public IActionResult Students([FromQuery] StudentQueryFilter filter)
    {
        var user = GetUser();
        if (user == null)
        {
            return RedirectToAction(nameof(HomePage));
        }
        var data = new StudentsViewModel
        {
            Students = studentsRepository.TeacherStudents(user.TeacherId, filter),
            Classes = classesRepository.GetClasses(user.TeacherId).Classes,
            NoteTypes = studentNoteRepository.GetNoteTypes(),
            Filter = filter
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

    [Authorize]
    [HttpPost]
    public IActionResult Students([FromForm] AddStudentDto addStudentDto)
    {
        studentsRepository.Add(addStudentDto, GetUser()!.UserTeacherId);
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
        var user = GetUser()!;
        examsRepository.AddExam(createExamDto, user.UserTeacherId);
        return Redirect(nameof(Exams));
    }

    [HttpDelete("DeleteExam/{id:int}")]
    public IActionResult DeleteExam(int id)
    {
        var user = GetUser()!;
        examsRepository.DeleteExam(id, user.UserTeacherId);
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
    [Authorize]
    public IActionResult Profile()
    {
        var user = GetUser();
        return View(user);
    }

    [Authorize]
    [HttpPost]
    public IActionResult UpdateProfile([FromForm] UpdateTeacherProfileDto update)
    {
        var teacher = GetUser()!.Teacher;
        teacherRepository.UpdateTeacher(update, teacher);
        return Redirect(nameof(Profile));
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
        return userRepository.GetUserById(id);
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
        studentNoteRepository.EditNote(editStudentNoteDto, GetUser()!.UserTeacherId);
        return Redirect(nameof(StudentNote));
    }

    public IActionResult LatestUpdates()
    {
        var userId = GetUser()!.UserTeacherId;
        var actionHistory = actionHistoryRepository.GetLastTenActions(userId);
        return PartialView("_LatestUpdates", actionHistory);
    }
}
