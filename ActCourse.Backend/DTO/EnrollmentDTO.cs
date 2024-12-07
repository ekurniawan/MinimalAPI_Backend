namespace ActCourse.Backend.DTO
{
    public class EnrollmentDTO
    {
        public int EnrollmentId { get; set; }
        public int InstructorId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrolledAt { get; set; }
    }
}
