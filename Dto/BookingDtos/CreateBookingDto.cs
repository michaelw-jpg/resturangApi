using resturangApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resturangApi.Dto.BookingDtos
{
    public class CreateBookingDto
    {
       
        public int? CustomerId_FK { get; set; }
        
        [MaxLength(100)]
        public string? Name { get; set; }
        
        [Phone(ErrorMessage = "Invalid Phone number")]
        [MaxLength(18)]
        public string? PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [MaxLength(50)]
        public string? Email { get; set; }
        [Required]
        public int TableId_FK { get; set; }

        [Required]
        public int Guests { get; set; }

        [Required]
        public DateTime BookingTime { get; set; }

      
    }
}
