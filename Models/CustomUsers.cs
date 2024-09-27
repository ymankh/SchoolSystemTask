using System.ComponentModel.DataAnnotations;

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

        public int TeacherId;

        public Teacher Teacher { get; set; }

    }
}
