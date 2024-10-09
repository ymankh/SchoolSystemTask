using Microsoft.EntityFrameworkCore;
using SchoolSystemTask.DTOs.ExamDTOs;
using SchoolSystemTask.Models;

namespace SchoolSystemTask.Repositories
{
    public class ExamsRepository(MyDbContext context)
    {
        public List<Exam> All()
        {
            return context.Exams.ToList();
        }

        public List<Exam> TeacherExams(int teacherId)
        {
            return context.Exams.Include(e => e.Class).ThenInclude(c => c.ClassSubjects).
            Where(e => e.Class.ClassSubjects.Any(cs => cs.TeacherSubjectId == teacherId))
            .ToList();
        }


        public void AddExam(CreateExamDto createExamDto)
        {
            var exam = new Exam()
            {

            };
            context.Exams.Add(exam);
            context.SaveChanges();
        }
    }
}