using SchoolSystemTask.Models;

namespace SchoolSystemTask.ViewModels
{
    public class StudentsViewModel
    {
        required public IEnumerable<Student> Students { get; set; }
        required public IEnumerable<Class> Classes { get; set; }
    }
}
