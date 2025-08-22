using System.ComponentModel.DataAnnotations;

namespace resturangApi.Models
{
    public class user
    {
        [Key]
        public Guid userId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}
