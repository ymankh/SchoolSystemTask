using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystemTask.Repositories;

namespace SchoolSystemTask.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentNoteController(StudentNoteRepository studentNoteRepository) : ControllerBase
    {
        [HttpDelete("{id:int}")]
        public IActionResult DeleteStudentNote(int id)
        {
            var studentNote = studentNoteRepository.DeleteStudentNote(id);
            if (studentNote != null) return NoContent();
            return NotFound();

        }
    }
}
