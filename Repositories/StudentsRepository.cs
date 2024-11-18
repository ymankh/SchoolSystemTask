using Microsoft.EntityFrameworkCore;
using SchoolSystemTask.DTOs.Filters;
using SchoolSystemTask.DTOs.StudentsDTOs;
using SchoolSystemTask.Models;
using SchoolSystemTask.Models.StaticData;

namespace SchoolSystemTask.Repositories;

public class StudentsRepository(MyDbContext context)
{

    public List<Student> TeacherStudents(int teacherId, StudentQueryFilter filter)
    {
        var students = context.Students.Include(s => s.Class.ClassSubjects).
            ThenInclude(cs => cs.TeacherSubject.Subject).
            Include(s => s.Class.Section).
            Include(s => s.StudentAbsences).
            Include(s => s.Class.Grade).
            Where(s => s.Class.TeacherId == teacherId ||
                        s.Class.ClassSubjects.Any(cs => cs.TeacherSubject.TeacherId == teacherId)).AsQueryable();
        if (filter.ClassId != null)
            students = students.Where(s => s.Class.Id == filter.ClassId);
        if (!string.IsNullOrEmpty(filter.Name))
            students = students.Where(s => s.FirstName.Contains(filter.Name) || s.SecondName.Contains(filter.Name) || s.ThirdName.Contains(filter.Name) || s.LastName.Contains(filter.Name));

        return students.ToList();
    }

    public List<Student> TeacherStudents(int teacherId)
    {
        var filter = new StudentQueryFilter();
        var students = context.Students.Include(s => s.Class.ClassSubjects).
            ThenInclude(cs => cs.TeacherSubject.Subject).
            Include(s => s.Class.Section).
            Include(s => s.StudentAbsences).
            Include(s => s.Class.Grade).
            Where(s => s.Class.TeacherId == teacherId ||
                        s.Class.ClassSubjects.Any(cs => cs.TeacherSubject.TeacherId == teacherId)).AsQueryable();
        if (filter.ClassId != null)
            students = students.Where(s => s.Class.Id == filter.ClassId);
        if (!string.IsNullOrEmpty(filter.Name))
            students = students.Where(s => s.FirstName.Contains(filter.Name) || s.SecondName.Contains(filter.Name) || s.ThirdName.Contains(filter.Name) || s.LastName.Contains(filter.Name));

        return students.ToList();
    }
    public IEnumerable<Student> All()
    {
        return context.Students.
            Include(s => s.StudentAbsences).
            Include(s => s.Class).
            ThenInclude(c => c.ClassSubjects).
            ThenInclude(cs => cs.TeacherSubject).
            ThenInclude(ts => ts.Subject).
            Include(s => s.Class).
            ThenInclude(c => c.Section).
            ToList();
    }

    public Student Add(AddStudentDto studentDto)
    {
        var name = SplitFullName(studentDto.FullName);
        var student = new Student
        {
            FirstName = name[0],
            SecondName = name.Length > 1 ? name[1] : "",
            ThirdName = name.Length > 1 ? name[2] : "",
            LastName = name[3],
            ClassId = studentDto.ClassId,
            ParentContact = studentDto.ParentContact,
            Address = studentDto.Address,
            BirthDate = studentDto.BirthDate,
            NationalId = studentDto.NationalId
        };
        context.Students.Add(student);
        context.ActionHistories.Add(new ActionHistory
        {
            Name = ActionNames.CreateStudent,
            Description = "Added a new student.",
            UserId = context.UserTeachers.First(u => u.Teacher.Classes.Any(u => u.Id == studentDto.ClassId)).UserTeacherId,
        });
        context.SaveChanges();
        return student;
    }
    private static string[] SplitFullName(string fullName)
    {
        var nameParts = fullName.Split(' ');

        var firstName = "";
        var secondName = "";
        var thirdName = "";
        var lastName = "";

        switch (nameParts.Length)
        {
            case 1:
                firstName = nameParts[0];
                break;
            case 2:
                firstName = nameParts[0];
                lastName = nameParts[1];
                break;
            case 3:
                firstName = nameParts[0];
                secondName = nameParts[1];
                lastName = nameParts[2];
                break;
            case >= 4:
                firstName = nameParts[0];
                secondName = nameParts[1];
                thirdName = nameParts[2];
                lastName = nameParts[^1];
                break;
        }
        return [firstName, secondName, thirdName, lastName];
    }

}

