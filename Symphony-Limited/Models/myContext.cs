using Microsoft.EntityFrameworkCore;

namespace Symphony_Limited.Models
{
    public class myContext : DbContext
    {
        public myContext(DbContextOptions<myContext> options) : base(options)
        {

        }
        public DbSet<Admin> tbl_admin { get; set; }
        public DbSet<Courses> tbl_courses { get; set; }
        public DbSet<Students> tbl_students { get; set; }
        public DbSet<Centres> tbl_centres { get; set; }
        public DbSet<FAQs> tbl_faqs { get; set; }
        public DbSet<ContactUs> tbl_contactus { get; set; }
        public DbSet<Course_Enrollment> tbl_courseEnrollment { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Entrance_Exam> EntranceExams { get; set; }
        public DbSet<Student_Exams> std_Exam { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student_Exams>()
                .HasOne(se => se.EntranceExam)
                .WithMany()
                .HasForeignKey(se => se.exam_id);

            // Configure relationships
            modelBuilder.Entity<Course_Enrollment>()
                .HasOne(ce => ce.Student)
                .WithMany(s => s.Course_Enrollments)
                .HasForeignKey(ce => ce.student_id);

            modelBuilder.Entity<Course_Enrollment>()
                .HasOne(ce => ce.Course)
                .WithMany(c => c.Course_Enrollments)
                .HasForeignKey(ce => ce.course_id);
        }

    }
}
