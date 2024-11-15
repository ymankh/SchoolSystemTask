using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystemTask.DTOs.StudentAbsenceDTOs
{
    public class CreateStudentAbsenceDto
    {
        [Required] public int StudentId { get; set; }
        [Required] public bool isAbsent { get; set; }
    }
}
