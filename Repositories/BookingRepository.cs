using Microsoft.EntityFrameworkCore;
using resturangApi.Data;
using resturangApi.Models;
using resturangApi.Repositories.Interface;

namespace resturangApi.Repositories
{
    public class BookingRepository(ResturangApiDbContext context) : IBookingRepository
    {
        private readonly ResturangApiDbContext _context = context;

        public async Task<List<Booking>> GetOldBookingsForGDPR(DateTime cutoffDate)
        { 
            var oldBookings = await _context.Bookings
                .Where(b => b.BookingTime < cutoffDate).ToListAsync();


            return oldBookings;
        }
      

    }
}
