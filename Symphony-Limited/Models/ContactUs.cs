using System.ComponentModel.DataAnnotations;

namespace Symphony_Limited.Models
{
    public class ContactUs
    {
        [Key]
        public int contactId {  get; set; } 
        public string contactName {  get; set; } 
        public string contactEmail {  get; set; } 
        public string contactSubject {  get; set; } 
        public string contactMessage {  get; set; } 
    }
}
