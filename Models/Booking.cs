using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resturangApi.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }


        //this is for later so eventually customers can login and see/handle their own bookings
        [ForeignKey("Customer")]
        public int? CustomerId_FK { get; set; }

        public virtual Customer? Customer { get; set; }

        // For guest users who do not have a Customer record
        [MaxLength(100)]
        public string? Name { get; set; }
       
        [Phone(ErrorMessage = "Invalid Phone number")]
        [MaxLength(18)]
        public string? PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [MaxLength(50)]
        public string? Email { get; set; }

        [Required]
        [ForeignKey("Table")]
        public int TableId_FK { get; set; }

        public virtual Table Table { get; set; }

        [Required]
        public int Guests { get; set; }

        [Required]
        public DateTime BookingTime { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    }
}
