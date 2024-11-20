using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSystemTask.Models;

namespace SchoolSystemTask.Controllers.Api;
[ApiController]
[Route("api/[controller]")]
public class UserApiController(MyDbContext context) : ControllerBase
{
    private Teacher GetTeacher()
    {
        var id = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        var teacher = context.UserTeachers.Include(u => u.Teacher).First(u => u.UserTeacherId == id).Teacher;
        return teacher;
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetCurrentTeacher()
    {
        return Ok(GetTeacher());
    }
}
