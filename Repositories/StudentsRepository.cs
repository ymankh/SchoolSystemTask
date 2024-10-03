using Microsoft.EntityFrameworkCore;
using SchoolSystemTask.DTOs.StudentsDTOs;
using SchoolSystemTask.Models;

namespace SchoolSystemTask.Repositories
{
    public class StudentsRepository(MyDbContext context)
    {
        public IEnumerable<Student> All()
        {
            return context.Students
                .Include(s => s.Class).
                ThenInclude(c => c.ClassSubjects).
                ThenInclude(cs => cs.TeacherSubject).
                ThenInclude(ts => ts.Subject).ToList();
        }

        public Student Add(AddStudentDto studentDto)
        {
            var name = studentDto.FullName.Split(' ');
            var student = new Student
            {
                FirstName = name[0],
                SecondName = name[1],
                ThirdName = name[2],
                LastName = name[3],
                ClassId = studentDto.ClassId,
                ParentContact = studentDto.ParentContact,
                Address = studentDto.Address,
                BirthDate = studentDto.BirthDate,
                NationalId = studentDto.NationalId
            };
            context.Students.Add(student);
            context.SaveChanges();
            return new Student
            {
                ClassId = studentDto.ClassId
            };
        }
    }
}
