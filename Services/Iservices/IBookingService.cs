using resturangApi.Dto.BookingDtos;
using resturangApi.Models;

namespace resturangApi.Services.Iservices
{
    public interface IBookingService
    {
      
        Task<Booking> CreateBookingAsync(CreateBookingDto dto);

        Task<List<Booking>> GetOldBookingsForGDPR(DateTime cutOffDate);
        
    }
}
