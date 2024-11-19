using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystemTask.Repositories;

namespace SchoolSystemTask.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentNoteController(StudentNoteRepository studentNoteRepository) : ControllerBase
    {
        private int GetUserId()
        {
            return Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
        [HttpDelete("{id:int}")]
        [Authorize]
        public IActionResult DeleteStudentNote(int id)
        {
            var studentNote = studentNoteRepository.DeleteStudentNote(id, GetUserId());
            if (studentNote != null) return NoContent();
            return NotFound();

        }
    }
}
