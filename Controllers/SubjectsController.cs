using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolSystemTask.Models.SchoolManagementSystem.Data;
using SchoolSystemTask.Repositories;

namespace SchoolSystemTask.Controllers
{
    public class SubjectsController(MyDbContext context) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var subjects = ClassesRepository.GetClasses();
            return View(subjects);
        }
    }
}