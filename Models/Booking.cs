using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resturangApi.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int CustomerId_FK { get; set; }

        public virtual Customer Customer { get; set; }

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
