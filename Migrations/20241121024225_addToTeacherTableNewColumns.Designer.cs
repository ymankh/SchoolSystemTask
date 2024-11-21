﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolSystemTask.Models;

#nullable disable

namespace SchoolSystemTask.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20241121024225_addToTeacherTableNewColumns")]
    partial class addToTeacherTableNewColumns
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("SchoolSystemTask.Models.ActionHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ActionHistories");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Assignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClassSubjectId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClassSubjectId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.AssignmentSubmission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AssignmentId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Submission")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("StudentId");

                    b.ToTable("AssignmentSubmissions");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GradeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SectionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GradeId");

                    b.HasIndex("SectionId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.ClassSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClassId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeacherSubjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherSubjectId");

                    b.ToTable("ClassSubjects");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClassId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClassSubjectId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("ExamDuration")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExamStartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ExamType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("MarkPublished")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxMark")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TeacherSubjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("ClassSubjectId");

                    b.HasIndex("TeacherSubjectId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.ExamMark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ExamId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Mark")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("StudentId");

                    b.ToTable("ExamMarks");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Grades");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Grade 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Grade 2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Grade 3"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Grade 4"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Grade 5"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Grade 6"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Grade 7"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Grade 8"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Grade 9"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Grade 10"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Grade 11"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Grade 12"
                        });
                });

            modelBuilder.Entity("SchoolSystemTask.Models.NoteType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NoteTypeName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("NoteTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NoteTypeName = "Positive"
                        },
                        new
                        {
                            Id = 2,
                            NoteTypeName = "Warning"
                        },
                        new
                        {
                            Id = 3,
                            NoteTypeName = "Improvement Needed"
                        },
                        new
                        {
                            Id = 4,
                            NoteTypeName = "Attendance"
                        },
                        new
                        {
                            Id = 5,
                            NoteTypeName = "Behavior"
                        },
                        new
                        {
                            Id = 6,
                            NoteTypeName = "Academic Performance"
                        },
                        new
                        {
                            Id = 7,
                            NoteTypeName = "Participation"
                        },
                        new
                        {
                            Id = 8,
                            NoteTypeName = "Homework Submission"
                        },
                        new
                        {
                            Id = 9,
                            NoteTypeName = "Punctuality"
                        },
                        new
                        {
                            Id = 10,
                            NoteTypeName = "Effort"
                        },
                        new
                        {
                            Id = 11,
                            NoteTypeName = "Teamwork"
                        },
                        new
                        {
                            Id = 12,
                            NoteTypeName = "Creativity"
                        },
                        new
                        {
                            Id = 13,
                            NoteTypeName = "Respect"
                        },
                        new
                        {
                            Id = 14,
                            NoteTypeName = "Leadership"
                        },
                        new
                        {
                            Id = 15,
                            NoteTypeName = "Organization"
                        });
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Sections");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "A"
                        },
                        new
                        {
                            Id = 2,
                            Name = "B"
                        },
                        new
                        {
                            Id = 3,
                            Name = "C"
                        },
                        new
                        {
                            Id = 4,
                            Name = "D"
                        },
                        new
                        {
                            Id = 5,
                            Name = "E"
                        },
                        new
                        {
                            Id = 6,
                            Name = "F"
                        },
                        new
                        {
                            Id = 7,
                            Name = "G"
                        },
                        new
                        {
                            Id = 8,
                            Name = "H"
                        });
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly?>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("ClassId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NationalId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ParentContact")
                        .HasColumnType("TEXT");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ThirdName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.StudentAbsence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TeacherSubjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherSubjectId");

                    b.ToTable("StudentAbsences");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.StudentClass", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(1);

                    b.Property<int>("ClassId")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(2);

                    b.HasKey("StudentId", "ClassId");

                    b.HasIndex("ClassId");

                    b.ToTable("StudentClasses");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.StudentDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("StudentDetails");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.StudentNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NoteTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("NoteTypeId");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("StudentNotes");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Mathematics"
                        },
                        new
                        {
                            Id = 2,
                            Name = "English"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Science"
                        },
                        new
                        {
                            Id = 4,
                            Name = "History"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Geography"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Computer Science"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Physics"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Chemistry"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Biology"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Physical Education"
                        });
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bio")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.Property<string>("Mobile")
                        .HasColumnType("TEXT");

                    b.Property<string>("SecondName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Specialty")
                        .HasColumnType("TEXT");

                    b.Property<string>("ThirdName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.TeacherSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherSubjects");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.UserStudent", b =>
                {
                    b.Property<int>("UserStudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserStudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("UserStudents");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.UserTeacher", b =>
                {
                    b.Property<int>("UserTeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .HasColumnType("TEXT");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserTeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("UserTeachers");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.ActionHistory", b =>
                {
                    b.HasOne("SchoolSystemTask.Models.UserTeacher", "UserTeacher")
                        .WithMany("ActionHistories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserTeacher");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Assignment", b =>
                {
                    b.HasOne("SchoolSystemTask.Models.ClassSubject", "ClassSubject")
                        .WithMany()
                        .HasForeignKey("ClassSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassSubject");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.AssignmentSubmission", b =>
                {
                    b.HasOne("SchoolSystemTask.Models.Assignment", "Assignment")
                        .WithMany()
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystemTask.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Class", b =>
                {
                    b.HasOne("SchoolSystemTask.Models.Grade", "Grade")
                        .WithMany("Classes")
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystemTask.Models.Section", "Section")
                        .WithMany("Classes")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystemTask.Models.Teacher", "Teacher")
                        .WithMany("Classes")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grade");

                    b.Navigation("Section");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.ClassSubject", b =>
                {
                    b.HasOne("SchoolSystemTask.Models.Class", "Class")
                        .WithMany("ClassSubjects")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystemTask.Models.Subject", null)
                        .WithMany("ClassSubjects")
                        .HasForeignKey("SubjectId");

                    b.HasOne("SchoolSystemTask.Models.TeacherSubject", "TeacherSubject")
                        .WithMany("ClassSubjects")
                        .HasForeignKey("TeacherSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("TeacherSubject");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Exam", b =>
                {
                    b.HasOne("SchoolSystemTask.Models.Class", null)
                        .WithMany("Exams")
                        .HasForeignKey("ClassId");

                    b.HasOne("SchoolSystemTask.Models.ClassSubject", "ClassSubject")
                        .WithMany("Exams")
                        .HasForeignKey("ClassSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystemTask.Models.TeacherSubject", null)
                        .WithMany("Exams")
                        .HasForeignKey("TeacherSubjectId");

                    b.Navigation("ClassSubject");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.ExamMark", b =>
                {
                    b.HasOne("SchoolSystemTask.Models.Exam", "Exam")
                        .WithMany("ExamMarks")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystemTask.Models.Student", "Student")
                        .WithMany("ExamMarks")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Student", b =>
                {
                    b.HasOne("SchoolSystemTask.Models.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.StudentAbsence", b =>
                {
                    b.HasOne("SchoolSystemTask.Models.Student", "Student")
                        .WithMany("StudentAbsences")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystemTask.Models.TeacherSubject", null)
                        .WithMany("StudentAbsences")
                        .HasForeignKey("TeacherSubjectId");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.StudentClass", b =>
                {
                    b.HasOne("SchoolSystemTask.Models.Class", "Class")
                        .WithMany("StudentClasses")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystemTask.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.StudentDetails", b =>
                {
                    b.HasOne("SchoolSystemTask.Models.Student", "Student")
                        .WithOne("StudentDetails")
                        .HasForeignKey("SchoolSystemTask.Models.StudentDetails", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.StudentNote", b =>
                {
                    b.HasOne("SchoolSystemTask.Models.NoteType", "NoteType")
                        .WithMany("StudentNotes")
                        .HasForeignKey("NoteTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystemTask.Models.Student", "Student")
                        .WithMany("StudentNotes")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystemTask.Models.Teacher", "Teacher")
                        .WithMany("StudentNotes")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NoteType");

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.TeacherSubject", b =>
                {
                    b.HasOne("SchoolSystemTask.Models.Subject", "Subject")
                        .WithMany("TeacherSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystemTask.Models.Teacher", "Teacher")
                        .WithMany("TeacherSubjects")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.UserStudent", b =>
                {
                    b.HasOne("SchoolSystemTask.Models.Teacher", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.UserTeacher", b =>
                {
                    b.HasOne("SchoolSystemTask.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Class", b =>
                {
                    b.Navigation("ClassSubjects");

                    b.Navigation("Exams");

                    b.Navigation("StudentClasses");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.ClassSubject", b =>
                {
                    b.Navigation("Exams");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Exam", b =>
                {
                    b.Navigation("ExamMarks");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Grade", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.NoteType", b =>
                {
                    b.Navigation("StudentNotes");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Section", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Student", b =>
                {
                    b.Navigation("ExamMarks");

                    b.Navigation("StudentAbsences");

                    b.Navigation("StudentDetails")
                        .IsRequired();

                    b.Navigation("StudentNotes");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Subject", b =>
                {
                    b.Navigation("ClassSubjects");

                    b.Navigation("TeacherSubjects");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Teacher", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("StudentNotes");

                    b.Navigation("TeacherSubjects");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.TeacherSubject", b =>
                {
                    b.Navigation("ClassSubjects");

                    b.Navigation("Exams");

                    b.Navigation("StudentAbsences");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.UserTeacher", b =>
                {
                    b.Navigation("ActionHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
