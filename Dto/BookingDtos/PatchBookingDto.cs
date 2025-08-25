using resturangApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resturangApi.Dto.BookingDtos
{
    public class PatchBookingDto
    {
        
       
        public int? CustomerId_FK { get; set; }


        public int? TableId_FK { get; set; }

  
        public int? Guests { get; set; }

        public DateTime? BookingTime { get; set; }

        
    }
}
