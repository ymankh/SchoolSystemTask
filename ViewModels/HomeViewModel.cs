using SchoolSystemTask.Models;

namespace SchoolSystemTask.ViewModels
{
    public class HomeViewModel
    {
        required public IEnumerable<Student> Students { get; set; }
    }
}
