using SchoolSystemTask.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSystemTask.DTOs.ExamDTOs
{
    public class CreateExamDto
    {

        public int ClassSubjectId { get; set; }

        public int MaxMark { get; set; }

        public DateTime ExamStartDate { get; set; }
        public string Details { get; set; } // Exam details (Material and other things)

        // Exam duration
        public TimeSpan ExamDuration { get; set; }
        public bool IsVisible { get; set; } // The student can see the exam or not

        public bool MarkPublished { get; set; }

        public string ExamType { get; set; } // Not Null

    }
}