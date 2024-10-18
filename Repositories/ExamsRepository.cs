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

        public List<Student>? GetExamMarks(int examId, int teacherId)
        {
            var exam = context.Exams.Find(examId);
            if (exam == null)
                return null;
            var studentClass = context.Classes.
            Include(sc => sc.Students).
            ThenInclude(s => s.ExamMarks).
            FirstOrDefault(c => c.Exams.Any(ex => ex.Id == examId));
            var students = studentClass.Students.ToList();
            foreach (var student in students)
            {
                var examMark = student.ExamMarks.FirstOrDefault(em => em.ExamId == examId);
                if (examMark == null)
                {
                    var newExamMark = new ExamMark
                    {
                        ExamId = examId,
                        StudentId = student.Id,
                        Mark = 0
                    };
                    context.ExamMarks.Add(newExamMark);
                    context.SaveChanges();
                }
            }
            return studentClass.Students.ToList();
        }
    }
}