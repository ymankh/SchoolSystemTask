namespace SchoolSystemTask.Repositories;

using Microsoft.EntityFrameworkCore;
using SchoolSystemTask.DTOs.ExamDTOs;
using SchoolSystemTask.DTOs.ExamMarksDTOs;
using SchoolSystemTask.Models;
using SchoolSystemTask.Models.StaticData;
using SchoolSystemTask.ViewModels;


public class ExamsRepository(MyDbContext context)
{
    public List<Exam> All()
    {
        return context.Exams.ToList();
    }

    public List<Exam> TeacherExams(int teacherId)
    {
        return context.Exams.Include(e => e.ClassSubject.TeacherSubject).
        Where(e => e.ClassSubject.TeacherSubject.TeacherId == teacherId)
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
            MarkPublished = false,
        };
        context.Exams.Add(exam);
        context.ActionHistories.Add(new ActionHistory
        {
            Name = ActionNames.CreateExam,
            Description = "Added a new exam.",
            UserId = context.UserTeachers.FirstAsync(u => u.Teacher.TeacherSubjects.Any(ts => ts.ClassSubjects.Any(cs => cs.Id == createExamDto.ClassSubjectId))).Id,
        });
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
        var examWithMarks = new List<AddExamMarkDto>();
        foreach (var student in students)
        {
            AddExamMarkDto newExamMark = new AddExamMarkDto
            {
                Id = student.ExamMarks.First(e => e.ExamId == examId).Id,
                Mark = student.ExamMarks.First(e => e.ExamId == examId).Mark
            };
            examWithMarks.Add(newExamMark);
        }
        return new ExamMarksViewModel
        {
            Students = students,
            Class = exam.ClassSubject.Class,
            Exam = exam,
            ExamWithMarks = examWithMarks
        };
    }

    internal void UpdateExamMark(AddExamMarkDto[] examMarksDto)
    {
        foreach (var mark in examMarksDto)
        {
            var examMark = context.ExamMarks.Find(mark.Id);
            examMark.Mark = mark.Mark;
            context.ExamMarks.Update(examMark);
        }
        context.ActionHistories.Add(new ActionHistory
        {
            Name = ActionNames.UpdateExamMark,
            Description = "Updated exam marks.",
            UserId = context.UserTeachers.FirstAsync(u => u.Teacher.TeacherSubjects.Any(ts => ts.ClassSubjects.Any(cs => cs.Id == examMarksDto[0].Id))).Id,
        });
        context.SaveChanges();
    }

    public void DeleteExam(int id)
    {
        var exam = context.Exams.Find(id) ?? throw new KeyNotFoundException("Exam not found");
        context.Exams.Remove(exam);
        context.ActionHistories.Add(new ActionHistory { Name = "DeleteExam", Id = exam.Id });
        context.ActionHistories.Add(new ActionHistory
        {
            Name = ActionNames.DeleteExam,
            Description = "Deleted an exam.",
            UserId = context.UserTeachers.FirstAsync(u => u.Teacher.TeacherSubjects.Any(ts => ts.ClassSubjects.Any(cs => cs.Id == id))).Id,
        });
        context.SaveChanges();
    }
}
