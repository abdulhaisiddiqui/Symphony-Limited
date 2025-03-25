using System.ComponentModel.DataAnnotations;

namespace Symphony_Limited.Models
{
    public class Courses
    {
        [Key]
        public int course_id { get; set; }
        public string? course_name { get; set; }
        public string? course_instructor { get; set; }
        public string? course_lectures { get; set; }
        public string? course_description { get; set; }
        public string? course_duration { get; set; }
        public string? course_image { get; set; }
        public string? course_fee { get; set; }
        public DateTime? DateAdded { get; set; }


        // Navigation property for Course_Enrollments
        public ICollection<Course_Enrollment> Course_Enrollments { get; set; }
    }
}
