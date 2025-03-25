using System.ComponentModel.DataAnnotations;

namespace Symphony_Limited.Models
{
    public class FAQs
    {
        [Key]
        public int faq_id { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
        public string date_posted { get; set; }
    }
}
