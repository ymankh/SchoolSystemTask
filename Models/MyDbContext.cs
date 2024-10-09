using Microsoft.EntityFrameworkCore;
namespace SchoolSystemTask.Models
{
    using Microsoft.EntityFrameworkCore;

    public class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options)
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentDetails> StudentDetails { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ClassSubject> ClassSubjects { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<UserTeacher> UserTeachers { get; set; }

        public DbSet<Exam> Exams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply configurations for each entity
            modelBuilder.ApplyConfiguration(new EntityConfiguration.GradeConfiguration());
            modelBuilder.ApplyConfiguration(new EntityConfiguration.SectionConfiguration());
            modelBuilder.ApplyConfiguration(new EntityConfiguration.SubjectConfiguration());

            // Configure composite keys
            modelBuilder.Entity<StudentClass>()
                .HasKey(sc => new { sc.StudentId, sc.ClassId });

            modelBuilder.Entity<ClassSubject>()
                .HasKey(cs => new { cs.ClassId, cs.TeacherSubjectId });
        }
    }

}
