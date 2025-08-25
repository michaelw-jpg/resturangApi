using System.ComponentModel.DataAnnotations;

namespace resturangApi.Dto.CustomerDtos
{
    public class PatchCustomerDto
    {


        
        [MaxLength(100)]
        public string? Name { get; set; }


        [Phone(ErrorMessage = "Invalid Phone number")]
        [MaxLength(18)]
        public string? PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [MaxLength(50)]
        public string? Email { get; set; }
    }
}
