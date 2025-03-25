using System.ComponentModel.DataAnnotations;

namespace Symphony_Limited.Models
{
    public class Instructor
    {
        [Key]
        public int instructorId {  get; set; }  
        public string instructorName {  get; set; }  
        public string instructorFaculty {  get; set; }  
        public string instructorImage {  get; set; }  
    }
}
