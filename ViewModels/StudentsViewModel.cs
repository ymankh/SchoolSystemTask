using SchoolSystemTask.Models;

namespace SchoolSystemTask.ViewModels
{
    public class StudentsViewModel
    {
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Class> Classes { get; set; }
    }
}
