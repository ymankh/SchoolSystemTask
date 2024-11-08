using Microsoft.AspNetCore.Mvc;
using SchoolSystemTask.DTOs.ExamMarksDTOs;
using SchoolSystemTask.Repositories;

namespace SchoolSystemTask.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamApiController(ExamsRepository examsRepository) : ControllerBase
    {
        [HttpPost]
        public IActionResult AddExamMarks([FromBody] AddExamMarkDto[] addExamMarkDto)
        {
            examsRepository.UpdateExamMark(addExamMarkDto);

            return Ok();
        }

    }
}