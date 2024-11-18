using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystemTask.Models
{
    public class UserTeacher
    {
        [Key]
        public int UserTeacherId { get; set; }
        [EmailAddress]
        required public string Email { get; set; }
        required public string PasswordHash { get; set; }
        required public string Salt { get; set; }
        public string? Role { get; set; }

        [ForeignKey("Teacher")]
        required public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }
        public ICollection<ActionHistory> ActionHistories { get; set; }

    }
}
