using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystemTask.Models
{
    public class UserTeacher
    {
        public int UserTeacherId { get; set; }
        [EmailAddress]

        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string? Role { get; set; }
        
        [ForeignKey("Teacher")]
        public int TeacherId;

        public Teacher Teacher { get; set; }

    }
}
