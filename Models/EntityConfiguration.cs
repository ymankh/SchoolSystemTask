using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SchoolSystemTask.Models
{
    public class EntityConfiguration
    {
        // Grade configuration
        public class GradeConfiguration : IEntityTypeConfiguration<Grade>
        {
            public void Configure(EntityTypeBuilder<Grade> builder)
            {
                builder.HasKey(g => g.Id);

                // Seeding the data
                builder.HasData(
                    new Grade { Id = 1, Name = "Grade 1" },
                    new Grade { Id = 2, Name = "Grade 2" },
                    new Grade { Id = 3, Name = "Grade 3" },
                    new Grade { Id = 4, Name = "Grade 4" },
                    new Grade { Id = 5, Name = "Grade 5" },
                    new Grade { Id = 6, Name = "Grade 6" },
                    new Grade { Id = 7, Name = "Grade 7" },
                    new Grade { Id = 8, Name = "Grade 8" },
                    new Grade { Id = 9, Name = "Grade 9" },
                    new Grade { Id = 10, Name = "Grade 10" },
                    new Grade { Id = 11, Name = "Grade 11" },
                    new Grade { Id = 12, Name = "Grade 12" }
                );
            }
        }

        // Section configuration
        public class SectionConfiguration : IEntityTypeConfiguration<Section>
        {
            public void Configure(EntityTypeBuilder<Section> builder)
            {
                builder.HasKey(s => s.Id);

                // Seeding the data
                builder.HasData(
                    new Section { Id = 1, Name = "A" },
                    new Section { Id = 2, Name = "B" },
                    new Section { Id = 3, Name = "C" },
                    new Section { Id = 4, Name = "D" },
                    new Section { Id = 5, Name = "E" },
                    new Section { Id = 6, Name = "F" },
                    new Section { Id = 7, Name = "G" },
                    new Section { Id = 8, Name = "H" }
                );
            }
        }

        // Subject configuration
        public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
        {
            public void Configure(EntityTypeBuilder<Subject> builder)
            {
                builder.HasKey(s => s.Id);

                // Seeding the data
                builder.HasData(
                    new Subject { Id = 1, Name = "Mathematics" },
                    new Subject { Id = 2, Name = "English" },
                    new Subject { Id = 3, Name = "Science" },
                    new Subject { Id = 4, Name = "History" },
                    new Subject { Id = 5, Name = "Geography" },
                    new Subject { Id = 6, Name = "Computer Science" },
                    new Subject { Id = 7, Name = "Physics" },
                    new Subject { Id = 8, Name = "Chemistry" },
                    new Subject { Id = 9, Name = "Biology" },
                    new Subject { Id = 10, Name = "Physical Education" }
                );
            }
        }
    }
}