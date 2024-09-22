using System.ComponentModel.DataAnnotations;

namespace SchoolSystemTask.Models
{
    public class UserTeacher
    {
        public int UserTeacherId { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }

        public int TeacherId;

        public Teacher Teacher { get; set; }

    }
}
