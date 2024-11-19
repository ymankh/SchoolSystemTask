using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystemTask.DTOs.StudentAbsenceDTOs;
using SchoolSystemTask.Models;
using SchoolSystemTask.Repositories;

namespace SchoolSystemTask.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbsenceController(AbsenceRepository absenceRepository) : ControllerBase
    {
        private int GetUserId()
        {
            return Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }

        [Authorize]
        [HttpPost]
        public IActionResult SaveAbsences([FromBody] CreateStudentAbsenceDto[] absences)
        {
            var userId = GetUserId();
            return Ok(absenceRepository.AddAbsences(absences, userId));
        }
    }
}
