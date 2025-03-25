    using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Symphony_Limited.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace Symphony_Limited.Controllers
{
    public class StudentController : Controller
    {
        private readonly myContext _context;
       

        // Constructor to inject ApplicationDbContext for database access
        public StudentController(myContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            List<Courses> courses = _context.tbl_courses.ToList();
            ViewData["courses"] = courses;
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var slogin = _context.tbl_students.FirstOrDefault(s => s.email == email && s.password == password);
            if (slogin != null)
            {
                HttpContext.Session.SetString("studentLogin", slogin.student_id.ToString());
                HttpContext.Session.SetString("studentEmail", slogin.email);
                return RedirectToAction("Index", "Student");
            }
            else
            {
                ViewData["errorMessage"] = "Incorrect Password or Email";
            }
            return View();
        }
        public IActionResult Register()
        {
            List<Courses> courses = _context.tbl_courses.ToList();
            ViewData["courses"] = courses;

            return View();
        }
        [HttpPost]
        public IActionResult Register(Students student)
        {
            _context.tbl_students.Add(student);
            _context.SaveChanges();

            return RedirectToAction("Login", "Student");

        }
        // Action method to display all available exams
        public IActionResult Index()
        {
            ViewBag.session = HttpContext.Session.GetString("studentLogin");

            List<Courses> courses = _context.tbl_courses.ToList();
            ViewData["courses"] = courses;

            List<Instructor> instructor = _context.Instructors.ToList();
            ViewData["instructor"] = instructor;

            var exams = _context.EntranceExams.ToList(); // Get all exams from the database
            return View(exams); // Pass exams data to the view for display
        }
        // Action method to register a student for an exam
        public IActionResult entranceExam()
        {
            List<Courses> courses = _context.tbl_courses.ToList();
            ViewData["courses"] = courses;


            ViewBag.session = HttpContext.Session.GetString("studentLogin");

            var exams = _context.EntranceExams.ToList(); // Get all exams from the database
            return View(exams); // Pass exams data to the view for display
        }
        [HttpPost]
        public IActionResult RegisterForExam1(int examId, int student_Id)
        {
          
            if (HttpContext.Session.GetString("studentLogin") == null)
            {
                return RedirectToAction("Login", "Student");
            }
            else
            {

                int? studentId = int.Parse(HttpContext.Session.GetString("studentLogin")); // Get student ID from session
            var studentExam = new Student_Exams
            {
                exam_id = examId,
                stu_id = studentId.Value,
                marksObtained = 0, // Initially, no marks
                examScore = "00.0%",// Class will be assigned after results
                examResult = "Pending" // Exam result will be set after the test
            };

            _context.std_Exam.Add(studentExam); // Add student exam record to database
            _context.SaveChanges(); // Save changes to the database

            return RedirectToAction("TakeTest", new { StudentExamId = studentExam.studentExamId }); // Redirect to the test page
            }
                                                                                                    
        }                                     
        // Action method for displaying the test
            public IActionResult TakeTest(int studentExamId)
            {
            string studentLoginSession = HttpContext.Session.GetString("studentLogin");

            if (string.IsNullOrEmpty(studentLoginSession))
            {
                TempData["ErrorMessage"] = "Session expired or not logged in. Please log in again.";
                return RedirectToAction("Login", "Student");
            }
            ViewBag.session = HttpContext.Session.GetString("studentLogin");

            int studentId = int.Parse(studentLoginSession);

            var studentExam = _context.std_Exam.Find(studentExamId);

            if (studentExam == null || studentExam.stu_id != studentId)
            {
                return NotFound();
            }

            // Proceed to display the test
            return View(studentExam); // Show the test to the student
        }
            [HttpPost]
            public IActionResult SubmitTestResults(int studentExamId, string q1, string q2, string q3, string q4, string q5,
                                                    string q6, string q7, string q8, string q9, string q10)
            {
                var studentExam = _context.std_Exam.Find(studentExamId);
                if (studentExam == null)
                {
                    return NotFound();
                }

                // Calculate marks based on answers
                int marks = 0;
                if (q1 == "B") marks++;
                if (q2 == "B") marks++;
                if (q3 == "B") marks++;
                if (q4 == "B") marks++;
                if (q5 == "A") marks++;
                if (q6 == "D") marks++;
                if (q7 == "C") marks++;
                if (q8 == "A") marks++;
                if (q9 == "A") marks++;
                if (q10 == "B") marks++;

                studentExam.marksObtained = marks;

                // Assign class based on marks
                if (marks >= 8)
                    studentExam.examScore = "A";
                else if (marks >= 6)
                    studentExam.examScore = "B";
                else
                    studentExam.examScore = "C";

                // Assign result based on marks
                studentExam.examResult = marks >= 5 ? "Pass" : "Fail";

                _context.std_Exam.Update(studentExam);
                _context.SaveChanges();

                return RedirectToAction("Result", new { studentExamId = studentExam.studentExamId });
            }
            public IActionResult Result(int studentExamId)
            {

                ViewBag.session = HttpContext.Session.GetString("studentLogin");

                List<Courses> courses = _context.tbl_courses.ToList();
                ViewData["courses"] = courses;
                var studentExam = _context.std_Exam.Find(studentExamId);
                if (studentExam == null)
                {
                    return NotFound();
                }

                return View(studentExam); // Pass the student exam data to the view
            }

            public IActionResult courseEnrollment()
            {
                List<Courses> courses = _context.tbl_courses.ToList();
                ViewData["courses"] = courses;
                return View();
            }

            public IActionResult CoursesDropdown()
            {
                List<Courses> courses = _context.tbl_courses.ToList();
                ViewData["courses"] = courses;
                return View();
            }
            public IActionResult CoursesCarousel()
            {
                List<Courses> courses = _context.tbl_courses.ToList();
                ViewData["courses"] = courses;
                ViewData["courses2"] = courses;

                return View(); // Ensure the partial view name starts with "_"
            }
            public IActionResult CourseDetail(int id)
            {

                ViewBag.session = HttpContext.Session.GetString("studentLogin");

                List<Courses> courses = _context.tbl_courses.ToList();
                ViewData["courses"] = courses;


                ViewData["recentcourses"] = courses;

                ViewData["categorycourses"] = courses;

                ViewData["courseDetailCarousel"] = courses;

                var row = _context.tbl_courses.Find(id);
                return View(row);
            }
            [HttpPost]
            public IActionResult sendContactMessage(ContactUs contact)
            {
                _context.tbl_contactus.Add(contact);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Your message has been sent successfully!"; // Store message
                return RedirectToAction("Index", "Student"); // Redirect back to the contact page
            }
            public IActionResult AboutUs()
            {
            ViewBag.session = HttpContext.Session.GetString("studentLogin");

            List<Courses> courses = _context.tbl_courses.ToList();
                ViewData["courses"] = courses;
                return View();

            }
            public IActionResult Course()
            {
                ViewBag.session = HttpContext.Session.GetString("studentLogin");

                List<Courses> courses = _context.tbl_courses.ToList();
                ViewData["latestCourses"] = courses;
                ViewData["courses"] = courses;

                List<Instructor> instructors = _context.Instructors.ToList();
                ViewData["instructor"] = instructors;
                return View();

            }
            public IActionResult regi()
            {
                var about = HttpContext.Session.GetString("studentLogin");
                if (about == null)
                {
                    return RedirectToAction("Login", "Student");
                }
                else
                {
                    return RedirectToAction("entranceExam", "Student");
                }
            }
            public IActionResult ContactUs()
            {
            ViewBag.session = HttpContext.Session.GetString("studentLogin");

            List<Courses> courses = _context.tbl_courses.ToList();
            ViewData["courses"] = courses;

            return View();

            }


        // GET: Enrollment/Enroll/{courseId}
        public async Task<IActionResult> Enroll(int courseId)
        {
            ViewBag.session = HttpContext.Session.GetString("studentLogin");
            // Get the logged-in student's ID
            var studentId = HttpContext.Session.GetString("studentLogin");

            if (string.IsNullOrEmpty(studentId))
            {
                return RedirectToAction("Login", "Student"); // Redirect to login if not authenticated
            }

            // Check if the student is already enrolled in the course
            var existingEnrollment = await _context.tbl_courseEnrollment
                .FirstOrDefaultAsync(ce => ce.student_id == int.Parse(studentId) && ce.course_id == courseId);

            if (existingEnrollment != null)
            {
                ViewBag.Message = "You are already enrolled in this course.";
                return View();
            }

            // Create a new enrollment
            var enrollment = new Course_Enrollment
            {
                student_id = int.Parse(studentId),
                course_id = courseId,
                enrollment_date = DateTime.Now.ToString("yyyy-MM-dd"),
                fee_paid = "0", // Assuming no fee is paid initially
                payment_status = "Pending"
            };

            _context.tbl_courseEnrollment.Add(enrollment);
            await _context.SaveChangesAsync();

            // Redirect to the payment page
            return RedirectToAction("Payment", new { enrollmentId = enrollment.enrollmentId });
        }
        public IActionResult Payment(int enrollmentId)
        {
            ViewBag.session = HttpContext.Session.GetString("studentLogin");
            // Retrieve the enrollment
            var enrollment = _context.tbl_courseEnrollment
                .Include(e => e.Course) // Include course details
                .FirstOrDefault(e => e.enrollmentId == enrollmentId);

            if (enrollment == null)
            {
                return NotFound();
            }

            // Pass the enrollment and course details to the view
            ViewBag.Enrollment = enrollment;
            ViewBag.Course = enrollment.Course;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ProcessPayment(int enrollmentId, string cardNumber, string expiryDate, string cvv)
        {
            ViewBag.session = HttpContext.Session.GetString("studentLogin");
            // Retrieve the enrollment with the related Course entity
            var enrollment = await _context.tbl_courseEnrollment
                .Include(e => e.Course) // Eager load the Course entity
                .FirstOrDefaultAsync(e => e.enrollmentId == enrollmentId);

            if (enrollment == null)
            {
                return NotFound();
            }

            // Ensure the Course entity is not null
            if (enrollment.Course == null)
            {
                return NotFound("Course details not found.");
            }

            // Simulate a successful payment
            var payment = new Payment
            {
                EnrollmentId = enrollmentId,
                TransactionId = Guid.NewGuid().ToString(), // Simulated transaction ID
                Amount = decimal.Parse(enrollment.Course.course_fee), // Assuming course_fee is a string
                PaymentStatus = "Success",
                PaymentDate = DateTime.Now
            };

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            // Update the enrollment payment status
            enrollment.payment_status = "Paid";
            _context.tbl_courseEnrollment.Update(enrollment);
            await _context.SaveChangesAsync();

            
            return RedirectToAction("PaymentConfirmation", "Student");
        }

        public IActionResult PaymentConfirmation()
        {
            ViewBag.session = HttpContext.Session.GetString("studentLogin");

            ViewBag.Message = "Payment successful!";
            TempData["PaymentSuccessMessage"] = "Payment successfull!";
            return View();
        }
        public IActionResult FAQs()
        {
            ViewBag.session = HttpContext.Session.GetString("studentLogin");

            List<Courses> courses = _context.tbl_courses.ToList();
            ViewData["courses"] = courses;

            var faq = _context.tbl_faqs.ToList();
            return View(faq);
        }
        public IActionResult Privacy()

            {
                
                return View();
            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
