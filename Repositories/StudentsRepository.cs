using Microsoft.EntityFrameworkCore;
using SchoolSystemTask.DTOs.Filters;
using SchoolSystemTask.DTOs.StudentsDTOs;
using SchoolSystemTask.Helpers;
using SchoolSystemTask.Models;
using SchoolSystemTask.Models.StaticData;

namespace SchoolSystemTask.Repositories;

public class StudentsRepository(MyDbContext context)
{
    public List<Student> TeacherStudents(int teacherId, StudentQueryFilter filter)
    {
        var students = context.Students.Include(s => s.Class.ClassSubjects).ThenInclude(cs => cs.TeacherSubject.Subject)
            .Include(s => s.Class.Section).Include(s => s.StudentAbsences).Include(s => s.Class.Grade).Where(s =>
                s.Class.TeacherId == teacherId ||
                s.Class.ClassSubjects.Any(cs => cs.TeacherSubject.TeacherId == teacherId)).AsQueryable();
        if (filter.ClassId != null)
            students = students.Where(s => s.Class.Id == filter.ClassId);
        if (!string.IsNullOrEmpty(filter.Name))
            students = students.Where(s =>
                (s.FirstName + " " + s.SecondName + " " + s.ThirdName + " " + s.LastName).ToLower()
                .Contains(filter.Name.ToLower()));

        return students.ToList();
    }

    public List<Student> TeacherStudents(int teacherId)
    {
        var filter = new StudentQueryFilter();
        return TeacherStudents(teacherId, filter);
    }

    public IEnumerable<Student> All()
    {
        return context.Students.Include(s => s.StudentAbsences).Include(s => s.Class).ThenInclude(c => c.ClassSubjects)
            .ThenInclude(cs => cs.TeacherSubject).ThenInclude(ts => ts.Subject).Include(s => s.Class)
            .ThenInclude(c => c.Section).ToList();
    }

    public Student Add(AddStudentDto studentDto, int userId)
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
            UserId = userId,
        });

        context.SaveChanges();
        return student;
    }

    private UserStudent CreateStudentAccount(Student student)
    {
        // Generate a unique salt for this user
        var salt = SaltHelper.GenerateSalt(16); // 16 bytes salt

        // Hash the password with the salt
        var hashedPassword = HashHelper.HashPassword(student.NationalId, salt);
        var user = new UserStudent
        {
            Email = student.StudentDetails.Email,
            PasswordHash = hashedPassword,
            Salt = salt,
            StudentId = student.Id
        };
        context.UserStudents.Add(user);
        context.SaveChanges();
        return user;
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