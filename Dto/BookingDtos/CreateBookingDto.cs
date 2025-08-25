using resturangApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resturangApi.Dto.BookingDtos
{
    public class CreateBookingDto
    {
        [Required]
        [ForeignKey("Customer")]
        public int CustomerId_FK { get; set; }

    

        [Required]
        [ForeignKey("Table")]
        public int TableId_FK { get; set; }

      

        [Required]
        public int Guests { get; set; }

        [Required]
        public DateTime BookingTime { get; set; }

      
    }
}
