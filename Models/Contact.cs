using System.ComponentModel.DataAnnotations;

namespace ChatApp.Models
{
    public class Contact
    {
        public int ContactId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ContactUserId { get; set; }

        public string ContactName { get; set; }
    }
}
