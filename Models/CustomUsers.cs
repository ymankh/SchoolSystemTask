﻿namespace SchoolSystemTask.Models;

using StaticData;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserTeacher
{
    [Key] public int UserTeacherId { get; set; }
    [EmailAddress] required public string Email { get; set; }
    required public string PasswordHash { get; set; }
    required public string Salt { get; set; }
    public string? Role { get; set; }

    [ForeignKey("Teacher")] required public int TeacherId { get; set; }

    public Teacher Teacher { get; set; }
    public ICollection<ActionHistory> ActionHistories { get; set; }
}

public class UserStudent
{
    [Key] public int UserStudentId { get; set; }
    [EmailAddress] required public string Email { get; set; }
    required public string PasswordHash { get; set; }
    required public string Salt { get; set; }

    [ForeignKey("Student")] required public int StudentId { get; set; }

    public Teacher Student { get; set; }
}

class Subsecription
{
    public int SubsecriptionId { get; set; }
    public string Plane { get; set; } = TeacherPlan.BASIC;
    public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public DateOnly EndDate { get; set; } = DateOnly.FromDateTime(DateTime.Now).AddMonths(1);
    public Teacher Teacher { get; set; }
}