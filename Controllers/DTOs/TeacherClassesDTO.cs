using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolSystemTask.Models;

namespace SchoolSystemTask.Controllers.DTOs
{
    public class TeacherClassesDTO
    {
        public IEnumerable<Class> Classes { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
        public IEnumerable<Grade> Grades { get; set; }
    }
}