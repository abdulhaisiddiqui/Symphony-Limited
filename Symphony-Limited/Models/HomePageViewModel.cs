namespace Symphony_Limited.Models
{
    public class HomePageViewModel
    {
        public int TotalStudents { get; set; } // Total number of students
        public decimal TotalPayments { get; set; } // Total payments received
        public int TotalCourses { get; set; } // Total number of courses
        public List<Students> RecentStudents { get; set; } // List of recent students
        public List<Payment> RecentPayments { get; set; } // List of recent payments
        public List<Courses> ActiveCourses { get; set; } // List of active courses
    }

}
