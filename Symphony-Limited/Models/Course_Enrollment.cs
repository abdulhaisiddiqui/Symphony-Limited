using System.ComponentModel.DataAnnotations;

namespace Symphony_Limited.Models
{
    public class Course_Enrollment
    {
        [Key]
        public int enrollmentId { get; set; }
        // Foreign key for Students
        public int student_id { get; set; }
        public Students Student { get; set; } // Navigation property

        // Foreign key for Courses
        public int course_id { get; set; }
        public Courses Course { get; set; } // Navigation property

        public string enrollment_date { get; set; }
        public string fee_paid { get; set; }
        public string payment_status { get; set; }
    }
}
