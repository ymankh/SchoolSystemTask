using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolSystemTask.DTOs.ExamMarksDTOs;
using SchoolSystemTask.Repositories;

namespace SchoolSystemTask.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamApiController(ExamsRepository examsRepository) : ControllerBase
    {
        private int GetUserId()
        {
            return Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddExamMarks([FromBody] AddExamMarkDto[] addExamMarkDto)
        {
            examsRepository.UpdateExamMark(addExamMarkDto, GetUserId());
            return Ok();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteExam(int id)
        {
            try
            {
                examsRepository.DeleteExam(id, GetUserId());
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Use NotFound() instead of BadRequest() for better clarity
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while deleting the exam.");
            }

            return Ok();
        }


    }
}