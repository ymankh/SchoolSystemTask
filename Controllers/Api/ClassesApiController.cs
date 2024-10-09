using Microsoft.AspNetCore.Mvc;
using SchoolSystemTask.DTOs.ClassesDTOs;
using SchoolSystemTask.Models;
using SchoolSystemTask.Repositories;

namespace SchoolSystemTask.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassesApiController(MyDbContext context, ClassesRepository classesRepository) : ControllerBase
    {
        //[HttpPost]
        //public IActionResult AddSubject([FromBody] AddSubjectToClassDto subject)
        //{
        //    var newClass = classesRepository.CreateClass(addClassDto);
        //    return Ok(newClass);
        //}
        [HttpGet("id:int")]
        public IActionResult GetClassSubjects(int id)
        {
            return Ok(classesRepository.GetClassSubjects(id))
        }
    }
}