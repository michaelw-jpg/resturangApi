using System.ComponentModel.DataAnnotations;

namespace resturangApi.Models
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public bool IsPopular { get; set; }

        [MaxLength(128)]
        public string? ImageUrl { get; set; }
    }
}
