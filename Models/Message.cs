using System.ComponentModel.DataAnnotations;

namespace ChatApp.Models
{
    public class Message
    {
        public int MessageId { get; set; }

        [Required]
        public int SenderId { get; set; }

        [Required]
        public int ReceiverId { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }
    }
}
