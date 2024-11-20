using Microsoft.AspNetCore.Mvc;
using SchoolSystemTask.DTOs.ClassesDTOs;
using SchoolSystemTask.Models;
using SchoolSystemTask.Repositories;

namespace SchoolSystemTask.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassesApiController(ClassesRepository classesRepository) : ControllerBase
    {
        [HttpGet("{id:int}")]
        public IActionResult GetClassSubjects(int id)
        {
            return Ok(classesRepository.GetClassSubjects(id));
        }
    }
}