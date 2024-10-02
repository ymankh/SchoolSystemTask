using SchoolSystemTask.Models;

namespace SchoolSystemTask.Helpers
{
    public class TeacherRepository(MyDbContext context)
    {
        public Teacher CreateTeacher(string firstName, string lastName)
        {
            var teacher = new Teacher
            {
                FirstName = firstName,
                LastName = lastName,
            };
            context.Teachers.Add(teacher);
            context.SaveChanges();
            return teacher;
        }
        public Teacher? GetTeacherByName(string firstName, string lastName)
        {
            return context.Teachers.FirstOrDefault(t => t.FirstName == firstName && t.LastName == lastName);
        }
    }
}
