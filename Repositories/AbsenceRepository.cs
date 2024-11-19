﻿using System.Linq;
using SchoolSystemTask.DTOs.StudentAbsenceDTOs;
using SchoolSystemTask.Models;
using SchoolSystemTask.Models.StaticData;

namespace SchoolSystemTask.Repositories
{
    public class AbsenceRepository(MyDbContext context)
    {
        public List<StudentAbsence> AddAbsences(CreateStudentAbsenceDto[] absences)
        {
            var today = DateTime.Now.Date;

            foreach (var absence in absences)
            {
                var existingAbsence = context.StudentAbsences
                    .FirstOrDefault(a => a.StudentId == absence.StudentId && a.DateTime.Date == today);

                if (absence.isAbsent && existingAbsence == null)
                {
                    // Add a new absence if the student is marked absent and no existing absence is found
                    context.StudentAbsences.Add(new StudentAbsence
                    {
                        DateTime = DateTime.Now,
                        StudentId = absence.StudentId
                    });
                }
                else if (!absence.isAbsent && existingAbsence != null)
                {
                    // Remove the existing absence if the student is not marked absent
                    context.StudentAbsences.Remove(existingAbsence);
                }
            }
            context.ActionHistories.Add(new ActionHistory
            {
                Name = ActionNames.CreateStudentAbsence,
                Description = "Added or removed absences.",
                UserId = context.UserTeachers.First(u => u.Teacher.TeacherSubjects.Any(ts => ts.ClassSubjects.Any(cs => cs.Id == absences[0].StudentId))).UserTeacherId,
            });
            context.SaveChanges();
            return context.StudentAbsences.ToList();
        }
    }
}