using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace resturangApi.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}
