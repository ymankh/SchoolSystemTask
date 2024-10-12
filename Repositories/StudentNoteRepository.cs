using SchoolSystemTask.DTOs.StudentNoteDTOs;
using SchoolSystemTask.Models;

namespace SchoolSystemTask.Repositories
{
    public class StudentNoteRepository(MyDbContext context)
    {
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
    }
}
