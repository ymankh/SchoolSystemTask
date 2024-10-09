using Microsoft.EntityFrameworkCore;
using SchoolSystemTask.DTOs.ClassesDTOs;
using SchoolSystemTask.Models;

namespace SchoolSystemTask.Repositories
{
    public class ClassesRepository(MyDbContext context)
    {
        public TeacherClassesDto GetClasses()
        {
            return new TeacherClassesDto
            {
                Classes = context.Classes.Include(c => c.ClassSubjects).ToList(),
                Subjects = context.Subjects.ToList(),
                Grades = context.Grades.ToList(),
                Sections = context.Sections.ToList()
            };
        }
        public TeacherClassesDto GetClasses(int teacherId)
        {
            return new TeacherClassesDto
            {
                Classes = context.Classes.
                    Include(c => c.ClassSubjects).
                    ThenInclude(c => c.TeacherSubject).
                    Where(c => c.ClassSubjects.Any(cs => cs.TeacherSubjectId == teacherId)).
                    ToList(),
                Subjects = context.Subjects.ToList(),
                Grades = context.Grades.ToList()
            };
        }
        public Class CreateClass(AddClassDto addClassDto, int teacherId)
        {
            var oldClass = context.Classes.FirstOrDefault(
                c => c.GradeId == addClassDto.GradeId && c.SectionId == addClassDto.SectionId && c.TeacherId == teacherId);
            if (oldClass != null)
            {
                return oldClass;
            }
            var newClass = new Class
            {
                GradeId = addClassDto.GradeId,
                SectionId = addClassDto.SectionId,
                TeacherId = teacherId
            };
            context.Classes.Add(newClass);
            context.SaveChanges();
            return newClass;
        }
    }
}