namespace SchoolSystemTask.Models
{
    using Microsoft.EntityFrameworkCore;

    namespace SchoolManagementSystem.Data
    {
        public class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options)
        {
            // DbSet properties for each model
            public DbSet<Student> Students { get; set; }
            public DbSet<Teacher> Teachers { get; set; }
            public DbSet<Grade> Grades { get; set; }
            public DbSet<Section> Sections { get; set; }
            public DbSet<Class> Classes { get; set; }
            public DbSet<Subject> Subjects { get; set; }
            public DbSet<TeachingAssignment> TeachingAssignments { get; set; }
            public DbSet<ClassSchedule> ClassSchedules { get; set; }
            public DbSet<Assignment> Assignments { get; set; }
            public DbSet<Event> Events { get; set; }
            public DbSet<Exam> Exams { get; set; }
            public DbSet<ExamMark> ExamMarks { get; set; }
            public DbSet<StudentNote> StudentNotes { get; set; }
            public DbSet<StudentNoteType> StudentNotesType { get; set; }
            public DbSet<UserTeacher> UserTeachers { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {

                modelBuilder.Entity<UserTeacher>()
                    .HasIndex(u => u.Email)
                    .IsUnique();

                // Seed Grades
                modelBuilder.Entity<Grade>().HasData(
                    new Grade { GradeId = 1, GradeName = "5th Grade" },
                    new Grade { GradeId = 2, GradeName = "6th Grade" }
                );

                // Seed Sections
                modelBuilder.Entity<Section>().HasData(
                    new Section { SectionId = 1, SectionName = "Section A", GradeId = 1 },
                    new Section { SectionId = 2, SectionName = "Section B", GradeId = 1 },
                    new Section { SectionId = 3, SectionName = "Section A", GradeId = 2 },
                    new Section { SectionId = 4, SectionName = "Section B", GradeId = 2 }
                );

                // Seed Subjects
                modelBuilder.Entity<Subject>().HasData(
                    new Subject { SubjectId = 1, SubjectName = "Mathematics" },
                    new Subject { SubjectId = 2, SubjectName = "Science" },
                    new Subject { SubjectId = 3, SubjectName = "History" },
                    new Subject { SubjectId = 4, SubjectName = "English" }
                );

                // Seed the relationships between Grades and Subjects
                modelBuilder.Entity<Grade>()
                    .HasMany(g => g.Subjects)
                    .WithMany(s => s.Grades)
                    .UsingEntity<Dictionary<string, object>>(
                        "GradeSubject",
                        r => r.HasOne<Subject>().WithMany().HasForeignKey("SubjectId"),
                        r => r.HasOne<Grade>().WithMany().HasForeignKey("GradeId"),
                        je =>
                        {
                            je.HasData(
                                new { GradeId = 1, SubjectId = 1 },  // 5th Grade - Mathematics
                                new { GradeId = 1, SubjectId = 2 },  // 5th Grade - Science
                                new { GradeId = 2, SubjectId = 3 },  // 6th Grade - History
                                new { GradeId = 2, SubjectId = 4 }   // 6th Grade - English
                            );
                        });
                modelBuilder.Entity<UserTeacher>()
                    .HasOne(s => s.Teacher)
                    .WithOne(sd => sd.UserTeacher)
                    .HasForeignKey<UserTeacher>(sd => sd.TeacherId);

                base.OnModelCreating(modelBuilder);

            }
        }
    }

}
