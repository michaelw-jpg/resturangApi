using System.ComponentModel.DataAnnotations;

namespace resturangApi.Models
{
    public class Table
    {
        [Key]
        public int TableId { get; set; }

        [Required]
        public int TableNumber { get; set; }
        [Required]
        public int Seats { get; set; }

        public ICollection<Booking>? Bookings { get; set; }

    }
}
