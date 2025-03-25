using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Symphony_Limited.Models;

namespace Symphony_Limited.Controllers
{
    public class AdminController : Controller
    {
        private myContext _context;
        private IWebHostEnvironment _env;
        public AdminController(myContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }

            
                // Fetch total number of students
                var totalStudents = _context.tbl_students.Count();

                // Fetch total payments received
                var totalPayments = _context.Payments.Sum(p => p.Amount);

                // Fetch total number of courses
                var totalCourses = _context.tbl_courses.Count();

                // Fetch recent students (last 5 registered students)
                var recentStudents = _context.tbl_students
                    .OrderByDescending(s => s.student_id)
                    .Take(5)
                    .ToList();

                // Fetch recent payments (last 5 payments)
                var recentPayments = _context.Payments
                    .OrderByDescending(p => p.PaymentDate)
                    .Take(5)
                    .ToList();

                // Fetch active courses
                var activeCourses = _context.tbl_courses
                    .OrderByDescending(c => c.course_id)
                    .Take(5)
                    .ToList();

                // Create ViewModel
                var viewModel = new HomePageViewModel
                {
                    TotalStudents = totalStudents,
                    TotalPayments = totalPayments,
                    TotalCourses = totalCourses,
                    RecentStudents = recentStudents,
                    RecentPayments = recentPayments,
                    ActiveCourses = activeCourses
                };

                return View(viewModel);
            
        }
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Login(string adminEmail, string adminPassword)
        {
            var row = _context.tbl_admin.FirstOrDefault(a => a.admin_email == adminEmail && a.admin_password == adminPassword);
            if (row != null)
            {
                HttpContext.Session.SetString("adminSession", row.admin_id.ToString());
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.message = "Incorrect Email Or Password";
                return View();
            }
        }
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("adminSession") != null)
            {
                HttpContext.Session.Remove("adminSession");
                _context.SaveChanges();
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View();
            }
        }


        public IActionResult Profile()
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {

                return RedirectToAction("Login", "Admin");

            }
            else
            {
                var adminId = HttpContext.Session.GetString("adminSession");
                var pro = _context.tbl_admin.Find(int.Parse(adminId));
                return View(pro);
            }
        }
        [HttpPost]
        public IActionResult Profile(Admin admin)
        {
            if (admin == null)
            {

                ViewBag.message = "Please Enter Values in Given Field";
            }
            else
            {
                _context.tbl_admin.Update(admin);
                _context.SaveChanges();
                return RedirectToAction("Profile", "Admin");
            }
            return View();
        }
        public IActionResult ChangeProfileImage(IFormFile admin_image, Admin admin)
        {
            string ImagePath = Path.Combine(_env.WebRootPath, "admin_images", admin_image.FileName);
            FileStream fs = new FileStream(ImagePath, FileMode.Create);
            admin_image.CopyTo(fs);
            admin.admin_image = admin_image.FileName;
            _context.tbl_admin.Update(admin);
            _context.SaveChanges();
            return RedirectToAction("Profile", "Admin");
        }


        public IActionResult fetchStudents()
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View(_context.tbl_students.ToList());

            }
        }
        public IActionResult studentDetails(int id)
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View(_context.tbl_students.FirstOrDefault(s => s.student_id == id));

            }
        }
        public IActionResult updateStudent(int id)
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                var row = _context.tbl_students.Find(id);
                return View(row);
            }

        }
        [HttpPost]
        public IActionResult updateStudent(Students std)
        {
            _context.tbl_students.Update(std);
            _context.SaveChanges();
            return RedirectToAction("fetchStudents", "Admin");
        }

        public IActionResult deleteStudentPermission(int id)
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                var row = _context.tbl_students.Find(id);
                return View(row);
            }


        }
        public IActionResult deleteStudent(int id)
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                var sid = _context.tbl_students.Find(id);
                _context.tbl_students.Remove(sid);
                _context.SaveChanges();
                return RedirectToAction("fetchStudents", "Admin");
            }

        }
        public IActionResult fetchCourses()
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View(_context.tbl_courses.ToList());

            }
        }
        public IActionResult addCourses()
        {
            return View();
        }
        [HttpPost]
        public IActionResult addCourses(Courses course, IFormFile course_image)
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {

                string ImagePath = Path.Combine(_env.WebRootPath, "course_images", course_image.FileName);
                FileStream fs = new FileStream(ImagePath, FileMode.Create);
                course_image.CopyTo(fs);
                course.course_image = course_image.FileName;

                _context.tbl_courses.Add(course);
                _context.SaveChanges();
                return RedirectToAction("fetchCourses", "Admin");


            }


        }
        public IActionResult updateCourse(int id)
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                var row = _context.tbl_courses.Find(id);
                return View(row);
            }

        }
        [HttpPost]
        public IActionResult updateCourse(Courses course)
        {
            _context.tbl_courses.Update(course);
            _context.SaveChanges();
            return RedirectToAction("fetchCourses", "Admin");
        }
        public IActionResult updateCourseImage(Courses course, IFormFile course_image)
        {
            string ImagePath = Path.Combine(_env.WebRootPath, "course_images", course_image.FileName);
            FileStream fs = new FileStream(ImagePath, FileMode.Create);
            course_image.CopyTo(fs);
            course.course_image = course_image.FileName;

            _context.tbl_courses.Update(course);
            _context.SaveChanges();
            return RedirectToAction("fetchCourses", "Admin");
        }
        public IActionResult deleteCoursePermission(int id)
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                var row = _context.tbl_courses.FirstOrDefault(c => c.course_id == id);
                return View(row);
            }

        }
        public IActionResult deleteCourse(int id)
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                var cid = _context.tbl_courses.Find(id);
                _context.tbl_courses.Remove(cid);
                _context.SaveChanges();
                return RedirectToAction("fetchCourses", "Admin");
            }

        }
        public IActionResult fetchEntranceExam()
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View(_context.EntranceExams.ToList());

            }

        }
        public IActionResult addEntranceExam()
        {
            return View();

        }
        [HttpPost]
        public IActionResult addEntranceExam(Entrance_Exam ent)
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {

                _context.EntranceExams.Add(ent);
                _context.SaveChanges();
                return RedirectToAction("fetchEntranceExam", "Admin");

            }

        }
        public IActionResult updateEntranceExam(int id)
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                var row = _context.EntranceExams.Find(id);
                return View(row);
            }


        }
        [HttpPost]
        public IActionResult updateEntranceExam(Entrance_Exam exam)
        {

            _context.EntranceExams.Update(exam);
            _context.SaveChanges();
            return RedirectToAction("fetchEntranceExam", "Admin");

        }
        public IActionResult deleteEntranceExamPermission(int id)
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                var row = _context.EntranceExams.Find(id);
                return View(row);
            }

        }
        public IActionResult deleteExam(int id)
        {
            var row = _context.EntranceExams.Find(id);
            _context.EntranceExams.Remove(row);
            _context.SaveChanges();
            return RedirectToAction("fetchEntranceExam", "Admin");
        }
        public IActionResult fetchResult()
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View(_context.std_Exam.ToList());

            }

        }
        public IActionResult deleteStudentExamsPermission(int id)
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                var row = _context.std_Exam.Find(id);
                return View(row);
            }
        }
        public IActionResult deleteStudentExam(int id)
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                var row = _context.std_Exam.Find(id);
                _context.std_Exam.Remove(row);
                _context.SaveChanges();
                return RedirectToAction("fetchResult", "Admin");
            }

        }
        public IActionResult fetchContactMessages()
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View(_context.tbl_contactus.ToList());

            }

        }

        public IActionResult deletePermissionContactMessages(int id)
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                var row = _context.tbl_contactus.FirstOrDefault(c => c.contactId == id);
                return View(row);
            }

        }
        public IActionResult deleteContact(int id)
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                var cid = _context.tbl_contactus.Find(id);
                _context.tbl_contactus.Remove(cid);
                _context.SaveChanges();
                return RedirectToAction("fetchContactMessages", "Admin");
            }

        }
        public IActionResult fetchCourseEnrollment()
        {

            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View(_context.tbl_courseEnrollment.Include(s => s.Student).Include(c => c.Course).ToList());

            }
        }

        public IActionResult deletePermissionCourseEnrollment(int id)
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                var row = _context.tbl_courseEnrollment.FirstOrDefault(e => e.enrollmentId == id);
                return View(row);
            }

        }
        public IActionResult deleteCourseEnrollment(int id)
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                var eid = _context.tbl_courseEnrollment.Find(id);
                _context.tbl_courseEnrollment.Remove(eid);
                _context.SaveChanges();
                return RedirectToAction("fetchCourseEnrollment", "Admin");
            }

        }
        public IActionResult fetchPayments()
        {

            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View(_context.Payments.ToList());

            }
        }
        public IActionResult deletePermissionPayment(int id)
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                var row = _context.Payments.FirstOrDefault(e => e.PaymentId == id);
                return View(row);
            }

        }
        public IActionResult deletePayment(int id)
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                var pid = _context.Payments.Find(id);
                _context.Payments.Remove(pid);
                _context.SaveChanges();
                return RedirectToAction("fetchPayments", "Admin");
            }
           
        }
        public IActionResult fetchFAQs()
        {

            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View(_context.tbl_faqs.ToList());

            }
        }
        public IActionResult addFAQ()
        {
            return View();

        }
        [HttpPost]
        public IActionResult addFAQ(FAQs faq)
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {

                _context.tbl_faqs.Add(faq);
                _context.SaveChanges();
                return RedirectToAction("fetchFAQs", "Admin");

            }

        }
        public IActionResult updateFAQ(int id)
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                var row = _context.tbl_faqs.Find(id);
                return View(row);
            }


        }
        [HttpPost]
        public IActionResult updateFAQ(FAQs faq)
        {

            _context.tbl_faqs.Update(faq);
            _context.SaveChanges();
            return RedirectToAction("fetchFAQs", "Admin");

        }
        public IActionResult deletePermissionFAQ(int id)
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                var row = _context.tbl_faqs.FirstOrDefault(e => e.faq_id == id);
                return View(row);
            }

        }
        public IActionResult deleteFAQ(int id)
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                var pid = _context.tbl_faqs.Find(id);
                _context.tbl_faqs.Remove(pid);
                _context.SaveChanges();
                return RedirectToAction("fetchFAQs", "Admin");
            }

        }
        public IActionResult fetchInstructor()
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View(_context.Instructors.ToList());

            }
        }
        public IActionResult addInstructor()
        {
            return View();

        }
        [HttpPost]
        public IActionResult addInstructor(Instructor ins,IFormFile instructorImage)
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {

                string ImagePath = Path.Combine(_env.WebRootPath, "instructor_images", instructorImage.FileName);
                FileStream fs = new FileStream(ImagePath, FileMode.Create);
                instructorImage.CopyTo(fs);
                ins.instructorImage = instructorImage.FileName;

                _context.Instructors.Add(ins);
                _context.SaveChanges();
                return RedirectToAction("fetchInstructor", "Admin");

            }

        }
        public IActionResult updateInstructor(int id)
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                var row = _context.Instructors.Find(id);
                return View(row);
            }


        }
        [HttpPost]
        public IActionResult updateInstructor(Instructor ins)
        {

            _context.Instructors.Update(ins);
            _context.SaveChanges();
            return RedirectToAction("fetchInstructor", "Admin");

        }
        public IActionResult updateInstructorImage(Instructor ins, IFormFile instructorImage)
        {

            if (instructorImage != null)
            {
                string ImagePath = Path.Combine(_env.WebRootPath, "instructor_images", instructorImage.FileName);

                using (FileStream fs = new FileStream(ImagePath, FileMode.Create))
                {
                    instructorImage.CopyTo(fs);
                }

                // Fetch the existing instructor from the database
                var existingInstructor = _context.Instructors.Find(ins.instructorId);
                if (existingInstructor == null)
                {
                    return NotFound(); // Instructor doesn't exist
                }

                // Update the instructor image field
                existingInstructor.instructorImage = instructorImage.FileName;

                _context.Instructors.Update(existingInstructor);
                _context.SaveChanges();
            }

            return RedirectToAction("fetchInstructor", "Admin");
        }
        public IActionResult deletePermissionInstructor(int id)
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                var row = _context.Instructors.FirstOrDefault(i => i.instructorId == id);
                return View(row);
            }

        }
        public IActionResult deleteInstructor(int id)
        {
            if (HttpContext.Session.GetString("adminSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                var iid = _context.Instructors.Find(id);
                _context.Instructors.Remove(iid);
                _context.SaveChanges();
                return RedirectToAction("fetchInstructor", "Admin");
            }

        }

    }
}
