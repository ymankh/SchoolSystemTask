using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSystemTask.DTOs.ExamDTOs
{
    public class CreateExamDto
    {

        public int TeacherSubjectId { get; set; } // Foreign Key
        public int ClassId { get; set; } // Foreign Key

        public DateTime ExamStartDate { get; set; }
        public string Detailes { get; set; } // Exam details (Material and other things)
        public int MaxMark { get; set; }

        // Exam duration
        public TimeSpan ExamDuration { get; set; }
        public bool IsVisible { get; set; } // Wither the student can see the exam or not

        public bool MarkPublished { get; set; }

        public string ExamType { get; set; } // Not Null

    }
}