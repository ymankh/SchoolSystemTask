namespace SchoolSystemTask.DTOs.StudentsDTOs
{
    public class AddStudentDto
    {
        public string FullName { get; set; }
        public int ClassId { get; set; }
        public string ParentContact { get; set; }
        public string Address { get; set; }
        public DateOnly BirthDate { get; set; }
        public string NationalId { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
    }
}
