using System.ComponentModel.DataAnnotations;

namespace Symphony_Limited.Models
{
    public class Student_Exams
    {
        [Key]
        public int studentExamId { get; set; }
        public int exam_id { get; set; }
        public int stu_id { get; set; }
        public int marksObtained { get; set; }
        public string examScore { get; set; }
        public string examResult { get; set; }
        //for relationship
        public Entrance_Exam EntranceExam { get; set; }
    }
}
