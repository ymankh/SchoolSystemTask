using Microsoft.EntityFrameworkCore;
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
    }
}
