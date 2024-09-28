using Microsoft.EntityFrameworkCore;
using SchoolSystemTask.Controllers.DTOs;
using SchoolSystemTask.Models;
using SchoolSystemTask.Models.SchoolManagementSystem.Data;

namespace SchoolSystemTask.Repositories
{
    public class ClassesRepository(MyDbContext context)
    {
        public TeacherClassesDTO GetClasses()
        {
            return new TeacherClassesDTO
            {
                Classes = context.Classes.Include(c => c.Subjects).ToList(),
                Subjects = context.Subjects.ToList(),
                Grades = context.Grades.ToList()
            };
        }
    }
}