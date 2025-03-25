using System.ComponentModel.DataAnnotations;

namespace Symphony_Limited.Models
{
    public class Centres
    {
        [Key]
        public int centre_id { get; set; }
        public string centre_name { get; set; }
        public string centre_address { get; set; }
        public string contact_number { get; set; }
        public string email { get; set; }
    }
}
