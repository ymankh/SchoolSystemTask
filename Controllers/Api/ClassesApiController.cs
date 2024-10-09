using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [HttpPost]
        public IActionResult CreateClass([FromBody] AddClassDto addClassDto)
        {
            var newClass = classesRepository.CreateClass(addClassDto);
            return Ok(newClass);
        }

    }
}