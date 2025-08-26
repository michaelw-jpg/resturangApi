using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resturangApi.Models
{
    public class Customer
    {
        //this is for later so eventually customers can login and see/handle their own bookings
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

       
        [Required, Phone(ErrorMessage = "Invalid Phone number")]
        [MaxLength(18)]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [MaxLength(50)]
        public string? Email { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

   

        public ICollection<Booking>? Bookings { get; set; }
    }
}
