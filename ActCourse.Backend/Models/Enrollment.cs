namespace ActCourse.Backend.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int InstructorId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrolledAt { get; set; }
        public Instructor Instructor { get; set; } = null!;
        public Course Course { get; set; } = null!;
    }
}
