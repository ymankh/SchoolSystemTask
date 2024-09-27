using Microsoft.EntityFrameworkCore;
using SchoolSystemTask.Models;
using SchoolSystemTask.Models.SchoolManagementSystem.Data;

namespace SchoolSystemTask.Repositories
{
    public class ClassesRepository(MyDbContext context)
    {
        public IEnumerable<Class> GetClasses()
        {
            return [.. context.Classes.Include(c => c.Subjects)];
        }
    }
}