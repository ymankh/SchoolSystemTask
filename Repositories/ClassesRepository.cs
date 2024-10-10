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
                    Where(c => c.TeacherId == teacherId || c.ClassSubjects.Any(cs => cs.TeacherSubjectId == teacherId)).
                    ToList(),
                Subjects = context.Subjects.ToList(),
                Sections = context.Sections.ToList(),
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

        public TeacherClassesDto CreateSubject(AddSubjectToClassDto addSubjectDto, int teacherId)
        {
            var oldClassSubject =
                context.ClassSubjects.FirstOrDefault(cs => cs.TeacherSubject.SubjectId == addSubjectDto.SubjectId);
            if (oldClassSubject != null)
                return GetClasses(teacherId);

            // Get or create teacher subject
            var teacherSubject = context.TeacherSubjects.FirstOrDefault(ts => ts.SubjectId == addSubjectDto.SubjectId && ts.TeacherId == teacherId);
            if (teacherSubject == null)
            {
                teacherSubject = new TeacherSubject
                {
                    SubjectId = addSubjectDto.SubjectId,
                    TeacherId = teacherId
                };
                context.TeacherSubjects.Add(teacherSubject);
                context.SaveChanges();
            }
            var classSubject = new ClassSubject
            {
                ClassId = addSubjectDto.ClassId,
                TeacherSubjectId = teacherSubject.Id
            };
            context.ClassSubjects.Add(classSubject);
            context.SaveChanges();
            return GetClasses(teacherId);
        }

        public List<ClassSubject> GetClassSubjects(int id)
        {
            return context.ClassSubjects.Include(cs => cs.TeacherSubject.Subject).Where(cs => cs.ClassId == id).ToList();
        }
    }
}