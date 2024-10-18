using Microsoft.EntityFrameworkCore;
using SchoolSystemTask.DTOs.ExamDTOs;
using SchoolSystemTask.Models;
using SchoolSystemTask.ViewModels;

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

        public ExamMarksViewModel? GetExamMarks(int examId, int teacherId)
        {
            var exam = context.Exams.
            Include(e => e.ClassSubject.TeacherSubject.Subject).
            Include(e => e.ClassSubject.Class.Section).
            Include(e => e.ClassSubject.Class.Grade).
            Include(e => e.ClassSubject.Class.Students).
            ThenInclude(s => s.ExamMarks).
            FirstOrDefault(e => e.Id == examId);
            if (exam == null || exam.ClassSubject.TeacherSubject.TeacherId != teacherId)
                return null;
            var students = exam.ClassSubject.Class.Students.ToList();
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
            return new ExamMarksViewModel
            {
                Students = students,
                Class = exam.ClassSubject.Class,
                Exam = exam
            };
        }
    }
}