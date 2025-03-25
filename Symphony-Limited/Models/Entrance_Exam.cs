using System.ComponentModel.DataAnnotations;

namespace Symphony_Limited.Models
{
    public class Entrance_Exam
    {
        [Key]
        public int examId { get; set; } // Primary Key
        public string examName { get; set; } // Name of the exam
        public string examDate { get; set; } // Date of the exam
        public decimal examFee { get; set; } // Exam fee
        public string CreatedAt { get; set; } // Timestamp when the exam was created

        
    }
}
