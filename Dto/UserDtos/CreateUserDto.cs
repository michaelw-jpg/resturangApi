using System.ComponentModel.DataAnnotations;

namespace resturangApi.Dto.UserDtos
{
    public class CreateUserDto
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}
