namespace ActCourse.Backend.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string UserName { get; set; } = null!;
        public string FullName { get; set; } = null!;

        public ICollection<Enrollment> Enrollments { get; set; } = null!;
    }
}
