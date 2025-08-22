using System.ComponentModel.DataAnnotations;

namespace resturangApi.Dto.MenuDtos
{
    public class PatchMenuDto
    {
        [MaxLength(50)]
        public string? Name { get; set; }
        public int? Price { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
        public bool? IsPopular { get; set; }
        [MaxLength(128)]
        public string? ImageUrl { get; set; }

        
    }
}
