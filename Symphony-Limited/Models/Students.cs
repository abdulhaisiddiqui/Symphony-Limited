using System.ComponentModel.DataAnnotations;

namespace Symphony_Limited.Models
{
    public class Students
    {
        [Key]
        public int student_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string? Country { get; set; }
        public string? date_of_birth { get; set; }
        public string? phone_number { get; set; }
        public string? gender { get; set; }


        // Navigation property for Course_Enrollments
        public ICollection<Course_Enrollment> Course_Enrollments { get; set; }
    }
}
