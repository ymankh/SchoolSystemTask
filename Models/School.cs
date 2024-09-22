using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystemTask.Models
{
    using System;
    using System.Collections.Generic;


    // Represents a student in the school
    public class Student
    {
        public int StudentId { get; set; }
        public string NationalId { get; set; }
        public required string FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? ThirdName { get; set; }
        public required string LastName { get; set; }
        public string? ParentContact { get; set; }
        public string? Address { get; set; }
        public DateOnly BirthDate { get; set; }



        // Navigation property
        public int ClassId { get; set; }
        public Class Class { get; set; }

        public ICollection<ExamMark> ExamMarks { get; set; }
        public ICollection<StudentNote> StudentNotes { get; set; }
    }

    // Represents a teacher who can teach multiple subjects and classes
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // Navigation properties
        public ICollection<TeachingAssignment> TeachingAssignments { get; set; }
        public ICollection<StudentNote> StudentNotes { get; set; }
        public UserTeacher UserTeacher { get; set; }
    }

    // Represents the grade level (e.g., 5th Grade)
    public class Grade
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; } // e.g., "5th Grade"

        // Navigation properties
        public ICollection<Section> Sections { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }

    // Represents a section within a grade (e.g., Section A)
    public class Section
    {
        public int SectionId { get; set; }
        public string SectionName { get; set; } // e.g., "Section A"

        // Navigation properties
        public int GradeId { get; set; }
        public Grade Grade { get; set; }
        public ICollection<Class> Classes { get; set; }
    }

    // Represents a class which is a combination of a grade and a section
    public class Class
    {
        public int ClassId { get; set; }

        // Navigation properties
        public int GradeId { get; set; }
        public Grade Grade { get; set; }

        public int SectionId { get; set; }
        public Section Section { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<ClassSchedule> ClassSchedules { get; set; }
    }

    // Represents a subject taught in the school
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        // Navigation properties
        public ICollection<TeachingAssignment> TeachingAssignments { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }

    // Represents the teaching assignment of a teacher to a class and subject
    public class TeachingAssignment
    {
        public int TeachingAssignmentId { get; set; }

        // Navigation properties
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }

    // Represents the schedule for a class
    public class ClassSchedule
    {
        public int ClassScheduleId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan Time { get; set; }

        // Navigation properties
        public int ClassId { get; set; }
        public Class Class { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }

    // Represents an assignment given to a class
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        // Navigation properties
        public int ClassId { get; set; }
        public Class Class { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }

    // Represents an event in the school
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }

        // Navigation properties
        public ICollection<Class> Classes { get; set; }
    }

    // Represents an exam for a subject and class
    public class Exam
    {
        public int ExamId { get; set; }
        public string ExamName { get; set; }
        public DateTime ExamDate { get; set; }

        // Navigation properties
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }

        public ICollection<ExamMark> ExamMarks { get; set; }
    }

    // Represents the mark a student received on an exam
    public class ExamMark
    {
        public int ExamMarkId { get; set; }
        public double Mark { get; set; }

        // Navigation properties
        public int ExamId { get; set; }
        public Exam Exam { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }

    public class StudentNoteType
    {
        public int StudentNoteTypeId { get; set; }
        public string NoteType { get; set; }
        public ICollection<StudentNote> StudentNotes { get; set; }
    }

    public class StudentNote
    {
        public int StudentNoteId { get; set; }
        public required string Note { get; set; }
        public string? Details { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public int TeacherId { get; set; }
        public int StudentId { get; set; }
        public int StudentNoteTypeId { get; set; }

        // Navigation properties
        public StudentNoteType StudentNoteType { get; set; }
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
    }
}