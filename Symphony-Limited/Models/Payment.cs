using System.ComponentModel.DataAnnotations;

namespace Symphony_Limited.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        public int EnrollmentId { get; set; } // Foreign key to Course_Enrollment
        public string TransactionId { get; set; } // Simulated transaction ID
        public decimal Amount { get; set; } // Payment amount
        public string PaymentStatus { get; set; } // Payment status (e.g., "Success", "Failed")
        public DateTime PaymentDate { get; set; } // Payment date
    }
}
