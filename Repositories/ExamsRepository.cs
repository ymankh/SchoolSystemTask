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
            return context.Exams.Include(e => e.ClassSubject).
            Where(e => e.ClassSubject.TeacherSubject.Id == teacherId)
            .ToList();
        }


        public void AddExam(CreateExamDto createExamDto)
        {
            var exam = new Exam()
            {
                ClassSubjectId = createExamDto.ClassSubjectId,
                Details = createExamDto.Details,
                IsVisible = createExamDto.IsVisible,
                ExamType = createExamDto.ExamType,
                ExamDuration = createExamDto.ExamDuration,
                ExamStartDate = createExamDto.ExamStartDate,
                MaxMark = createExamDto.MaxMark,
                MarkPublished = false
            };
            context.Exams.Add(exam);
            context.SaveChanges();
        }
    }
}