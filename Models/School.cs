using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;

namespace SchoolSystemTask.Models
{
    public class Student
    {
        public int Id { get; set; } // Primary Key

        public string FirstName { get; set; } // Not Null
        public string SecondName { get; set; } // Not Null
        public string ThirdName { get; set; } // Not Null
        public string LastName { get; set; } // Not Null
        public string? ParentContact { get; set; }
        public string? Address { get; set; }
        public DateOnly? BirthDate { get; set; }
        public string? NationalId { get; set; }

        public int ClassId { get; set; } // Foreign Key
        public Class Class { get; set; } // Navigation Property

        public StudentDetails StudentDetails { get; set; } // Navigation Property

        public ICollection<StudentAbsence> StudentAbsences { get; set; }
        public ICollection<ExamMark> ExamMarks { get; set; }
        public ICollection<StudentNote> StudentNotes { get; set; }
    }
    public class Class
    {
        public int Id { get; set; } // Primary Key

        public int GradeId { get; set; } // Foreign Key

        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public Grade Grade { get; set; } // Navigation Property

        public int SectionId { get; set; } // Foreign Key
        public Section Section { get; set; } // Navigation Property

        public ICollection<Student> Students { get; set; }
        public ICollection<ClassSubject> ClassSubjects { get; set; }
        public ICollection<StudentClass> StudentClasses { get; set; }
        public ICollection<Exam> Exams { get; set; }

        public string ClassName()
        {
            return this.Grade.Name + ", " + this.Section.Name;
        }
    }
    public class StudentClass
    {
        public int StudentId { get; set; } // Composite Primary Key
        public Student Student { get; set; } // Navigation Property

        public int ClassId { get; set; } // Composite Primary Key
        public Class Class { get; set; } // Navigation Property
    }

    public class StudentAbsence
    {
        public int Id { get; set; } // Primary Key

        public DateTime Datetime { get; set; } // Not Null

        public int TeacherSubjectId { get; set; } // Foreign Key
        public TeacherSubject TeacherSubject { get; set; } // Navigation Property

        public int StudentId { get; set; } // Foreign Key
        public Student Student { get; set; } // Navigation Property
    }
    public class ExamMark
    {
        public int Id { get; set; } // Primary Key

        public int StudentId { get; set; } // Foreign Key
        public Student Student { get; set; } // Navigation Property

        public int Mark { get; set; } // Not Null

        public int ExamId { get; set; } // Foreign Key
        public Exam Exam { get; set; } // Navigation Property
    }

    public class NoteType
    {
        public int Id { get; set; } // Primary Key

        public string NoteTypeName { get; set; } // Not Null

        public ICollection<StudentNote> StudentNotes { get; set; }
    }

    public class Subject
    {
        public int Id { get; set; } // Primary Key

        public string Name { get; set; } // Not Null

        public ICollection<TeacherSubject> TeacherSubjects { get; set; }
        public ICollection<ClassSubject> ClassSubjects { get; set; }
    }

    public class Exam
    {
        public int Id { get; set; } // Primary Key

        [ForeignKey("ClassSubject")]
        public int ClassSubjectId { get; set; }

        public ClassSubject ClassSubject { get; set; }

        public int MaxMark { get; set; }

        public DateTime ExamStartDate { get; set; }
        public string Details { get; set; } // Exam details (Material and other things)

        // Exam duration
        public TimeSpan ExamDuration { get; set; }
        public bool IsVisible { get; set; } // Either the student can see the exam or not

        public bool MarkPublished { get; set; }

        public string ExamType { get; set; } // Not Null

        public ICollection<ExamMark> ExamMarks { get; set; }
    }

    public class StudentNote
    {
        public int Id { get; set; } // Primary Key

        public string Note { get; set; } // Not Null

        public int NoteTypeId { get; set; } // Foreign Key
        public NoteType NoteType { get; set; } // Navigation Property

        public int StudentId { get; set; } // Foreign Key
        public Student Student { get; set; } // Navigation Property

        public int TeacherId { get; set; } // Foreign Key
        public Teacher Teacher { get; set; } // Navigation Property
    }

    public class ClassSubject
    {
        [Key]
        public int Id { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; } // Navigation Property

        [ForeignKey("TeacherSubject")]
        public int TeacherSubjectId { get; set; }
        public TeacherSubject TeacherSubject { get; set; } // Navigation Property
    }

    public class Grade
    {
        public int Id { get; set; } // Primary Key

        public string Name { get; set; } // Not Null

        public ICollection<Class> Classes { get; set; }
    }

    public class Teacher
    {
        public int Id { get; set; } // Primary Key

        public string FirstName { get; set; } // Not Null
        public string? SecondName { get; set; } // Not Null
        public string? ThirdName { get; set; } // Not Null
        public string LastName { get; set; } // Not Null


        public ICollection<Class> Classes { get; set; }
        public ICollection<TeacherSubject> TeacherSubjects { get; set; }
        public ICollection<StudentNote> StudentNotes { get; set; }
    }

    public class StudentDetails
    {
        public int Id { get; set; } // Primary Key

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public string Email { get; set; } // Not Null

        public Student Student { get; set; } // Navigation Property
    }

    public class TeacherSubject
    {
        public int Id { get; set; } // Primary Key

        public int TeacherId { get; set; } // Foreign Key
        public Teacher Teacher { get; set; } // Navigation Property

        public int SubjectId { get; set; } // Foreign Key
        public Subject Subject { get; set; } // Navigation Property

        public ICollection<StudentAbsence> StudentAbsences { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }

    public class Section
    {
        public int Id { get; set; } // Primary Key

        [MaxLength(255)]
        public required string Name { get; set; } // Not Null

        public ICollection<Class> Classes { get; set; }
    }

}