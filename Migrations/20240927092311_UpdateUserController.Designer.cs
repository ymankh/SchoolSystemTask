﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolSystemTask.Models.SchoolManagementSystem.Data;

#nullable disable

namespace SchoolSystemTask.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240927092311_UpdateUserController")]
    partial class UpdateUserController
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("GradeSubject", b =>
                {
                    b.Property<int>("GradeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GradeId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("GradeSubject");

                    b.HasData(
                        new
                        {
                            GradeId = 1,
                            SubjectId = 1
                        },
                        new
                        {
                            GradeId = 1,
                            SubjectId = 2
                        },
                        new
                        {
                            GradeId = 2,
                            SubjectId = 3
                        },
                        new
                        {
                            GradeId = 2,
                            SubjectId = 4
                        });
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Assignment", b =>
                {
                    b.Property<int>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClassId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AssignmentId");

                    b.HasIndex("ClassId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Class", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GradeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SectionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ClassId");

                    b.HasIndex("EventId");

                    b.HasIndex("GradeId");

                    b.HasIndex("SectionId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.ClassSchedule", b =>
                {
                    b.Property<int>("ClassScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClassId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("TEXT");

                    b.HasKey("ClassScheduleId");

                    b.HasIndex("ClassId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("ClassSchedules");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("EventId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Exam", b =>
                {
                    b.Property<int>("ExamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClassId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ExamDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ExamName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ExamId");

                    b.HasIndex("ClassId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.ExamMark", b =>
                {
                    b.Property<int>("ExamMarkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ExamId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Mark")
                        .HasColumnType("REAL");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ExamMarkId");

                    b.HasIndex("ExamId");

                    b.HasIndex("StudentId");

                    b.ToTable("ExamMarks");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Grade", b =>
                {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("GradeName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GradeId");

                    b.ToTable("Grades");

                    b.HasData(
                        new
                        {
                            GradeId = 1,
                            GradeName = "5th Grade"
                        },
                        new
                        {
                            GradeId = 2,
                            GradeName = "6th Grade"
                        });
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Section", b =>
                {
                    b.Property<int>("SectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GradeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SectionName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SectionId");

                    b.HasIndex("GradeId");

                    b.ToTable("Sections");

                    b.HasData(
                        new
                        {
                            SectionId = 1,
                            GradeId = 1,
                            SectionName = "Section A"
                        },
                        new
                        {
                            SectionId = 2,
                            GradeId = 1,
                            SectionName = "Section B"
                        },
                        new
                        {
                            SectionId = 3,
                            GradeId = 2,
                            SectionName = "Section A"
                        },
                        new
                        {
                            SectionId = 4,
                            GradeId = 2,
                            SectionName = "Section B"
                        });
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("BirthDate")
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
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ParentContact")
                        .HasColumnType("TEXT");

                    b.Property<string>("SecondName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ThirdName")
                        .HasColumnType("TEXT");

                    b.HasKey("StudentId");

                    b.HasIndex("ClassId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.StudentNote", b =>
                {
                    b.Property<int>("StudentNoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Details")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentNoteTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.HasKey("StudentNoteId");

                    b.HasIndex("StudentId");

                    b.HasIndex("StudentNoteTypeId");

                    b.HasIndex("TeacherId");

                    b.ToTable("StudentNotes");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.StudentNoteType", b =>
                {
                    b.Property<int>("StudentNoteTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NoteType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("StudentNoteTypeId");

                    b.ToTable("StudentNotesType");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SubjectId");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            SubjectId = 1,
                            SubjectName = "Mathematics"
                        },
                        new
                        {
                            SubjectId = 2,
                            SubjectName = "Science"
                        },
                        new
                        {
                            SubjectId = 3,
                            SubjectName = "History"
                        },
                        new
                        {
                            SubjectId = 4,
                            SubjectName = "English"
                        });
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.TeachingAssignment", b =>
                {
                    b.Property<int>("TeachingAssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClassId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TeachingAssignmentId");

                    b.HasIndex("ClassId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeachingAssignments");
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

                    b.HasIndex("TeacherId")
                        .IsUnique();

                    b.ToTable("UserTeachers");
                });

            modelBuilder.Entity("GradeSubject", b =>
                {
                    b.HasOne("SchoolSystemTask.Models.Grade", null)
                        .WithMany()
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystemTask.Models.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Assignment", b =>
                {
                    b.HasOne("SchoolSystemTask.Models.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystemTask.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Class", b =>
                {
                    b.HasOne("SchoolSystemTask.Models.Event", null)
                        .WithMany("Classes")
                        .HasForeignKey("EventId");

                    b.HasOne("SchoolSystemTask.Models.Grade", "Grade")
                        .WithMany()
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystemTask.Models.Section", "Section")
                        .WithMany("Classes")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grade");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.ClassSchedule", b =>
                {
                    b.HasOne("SchoolSystemTask.Models.Class", "Class")
                        .WithMany("ClassSchedules")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystemTask.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystemTask.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Exam", b =>
                {
                    b.HasOne("SchoolSystemTask.Models.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystemTask.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Subject");
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

            modelBuilder.Entity("SchoolSystemTask.Models.Section", b =>
                {
                    b.HasOne("SchoolSystemTask.Models.Grade", "Grade")
                        .WithMany("Sections")
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grade");
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

            modelBuilder.Entity("SchoolSystemTask.Models.StudentNote", b =>
                {
                    b.HasOne("SchoolSystemTask.Models.Student", "Student")
                        .WithMany("StudentNotes")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystemTask.Models.StudentNoteType", "StudentNoteType")
                        .WithMany("StudentNotes")
                        .HasForeignKey("StudentNoteTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystemTask.Models.Teacher", "Teacher")
                        .WithMany("StudentNotes")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("StudentNoteType");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.TeachingAssignment", b =>
                {
                    b.HasOne("SchoolSystemTask.Models.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystemTask.Models.Subject", "Subject")
                        .WithMany("TeachingAssignments")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystemTask.Models.Teacher", "Teacher")
                        .WithMany("TeachingAssignments")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.UserTeacher", b =>
                {
                    b.HasOne("SchoolSystemTask.Models.Teacher", "Teacher")
                        .WithOne("UserTeacher")
                        .HasForeignKey("SchoolSystemTask.Models.UserTeacher", "TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Class", b =>
                {
                    b.Navigation("ClassSchedules");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Event", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Exam", b =>
                {
                    b.Navigation("ExamMarks");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Grade", b =>
                {
                    b.Navigation("Sections");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Section", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Student", b =>
                {
                    b.Navigation("ExamMarks");

                    b.Navigation("StudentNotes");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.StudentNoteType", b =>
                {
                    b.Navigation("StudentNotes");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Subject", b =>
                {
                    b.Navigation("TeachingAssignments");
                });

            modelBuilder.Entity("SchoolSystemTask.Models.Teacher", b =>
                {
                    b.Navigation("StudentNotes");

                    b.Navigation("TeachingAssignments");

                    b.Navigation("UserTeacher")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
