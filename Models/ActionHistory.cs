namespace SchoolSystemTask.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class ActionHistory
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    [ForeignKey(nameof(UserTeacher))]
    public int UserId { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public UserTeacher UserTeacher { get; set; }
}
