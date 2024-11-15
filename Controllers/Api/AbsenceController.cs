using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystemTask.DTOs.StudentAbsenceDTOs;
using SchoolSystemTask.Repositories;

namespace SchoolSystemTask.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbsenceController(AbsenceRebasatory absenceRebasatory) : ControllerBase
    {
        [HttpPost]
        public IActionResult SaveAbcences([FromBody] CreateStudentAbsenceDto[] absences)
        {
            var abcences = absenceRebasatory.AddAbsences(absences);
            return Ok(abcences);
        }
    }
}
