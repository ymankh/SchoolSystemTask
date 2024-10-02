using Microsoft.EntityFrameworkCore;
using SchoolSystemTask.Controllers.DTOs;
using SchoolSystemTask.DTOs.ClassesDTOs;
using SchoolSystemTask.Models;

namespace SchoolSystemTask.Repositories
{
    public class ClassesRepository(MyDbContext context)
    {
        public TeacherClassesDTO GetClasses()
        {
            return new TeacherClassesDTO
            {
                Classes = context.Classes.Include(c => c.ClassSubjects).ToList(),
                Subjects = context.Subjects.ToList(),
                Grades = context.Grades.ToList()
            };
        }
        public TeacherClassesDTO GetClasses(int TeacherId)
        {
            return new TeacherClassesDTO
            {
                Classes = context.Classes.Include(c => c.ClassSubjects).ThenInclude(c => c.TeacherSubject).Where(c => c.ClassSubjects.Any(cs => cs.TeacherSubjectId == TeacherId)).ToList(),
                Subjects = context.Subjects.ToList(),
                Grades = context.Grades.ToList()
            };
        }
        public Class CreateClass(AddClassDto addClassDto)
        {
            var newClass = new Class
            {
                GradeId = addClassDto.GradeId,
                SectionId = addClassDto.SectionId
            };
            context.Classes.Add(newClass);
            context.SaveChanges();
            return newClass;
        }
    }
}