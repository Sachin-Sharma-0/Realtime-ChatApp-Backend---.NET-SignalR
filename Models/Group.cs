using System.ComponentModel.DataAnnotations;

namespace ChatApp.Models
{
    public class Group
    {
        public int GroupId { get; set; }

        [Required]
        public string GroupName { get; set; }

        [Required]
        public int CreatorId { get; set; }
    }
}
