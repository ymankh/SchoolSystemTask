using Microsoft.EntityFrameworkCore;
using SchoolSystemTask.DTOs.StudentNoteDTOs;
using SchoolSystemTask.Models;

namespace SchoolSystemTask.Repositories
{
    public class StudentNoteRepository(MyDbContext context)
    {
        public List<StudentNote> GetTeacherStudentNotes(int teacherId)
        {
            return context.StudentNotes.Where(s => s.TeacherId == teacherId).Include(sn => sn.NoteType)
                .Include(s => s.Student.Class.ClassSubjects)
                .ThenInclude(classSubject => classSubject.TeacherSubject.Subject)
                .ToList();
        }

        public List<StudentNote> GetStudentNotes(int studentId)
        {
            return context.StudentNotes.Where(s => s.StudentId == studentId).ToList();
        }

        public StudentNote AddStudentNote(CreateStudentNoteDto newNote, int teacherId)
        {
            var studentNote = new StudentNote
            {
                Note = newNote.Note,
                NoteTypeId = newNote.NoteTypeId,
                StudentId = newNote.StudentId,
                TeacherId = teacherId
            };
            context.StudentNotes.Add(studentNote);
            context.SaveChanges();
            return studentNote;
        }

        internal void DeleteStudentNote(int id, int teacherId)
        {
            var studentNote = context.StudentNotes.Find(id);
            if (studentNote == null)
                return;

            studentNote.TeacherId = teacherId;
            context.StudentNotes.Remove(studentNote);
            context.SaveChanges();
        }
    }
}