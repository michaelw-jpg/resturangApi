using Microsoft.EntityFrameworkCore;
using resturangApi.Data;
using resturangApi.Models;
using resturangApi.Repositories.Interface;

namespace resturangApi.Repositories
{
    public class TableRepository(ResturangApiDbContext context) : ITableRepository
    {
        private readonly ResturangApiDbContext _context = context;

        public async Task<List<Table>> GetAllAvailableTables(DateTime bookingDate, int guests)
        {
           var bookingStart = bookingDate;
           var bookingEnd = bookingDate.AddHours(2); // Assuming a 2-hour booking duration

            var availableTables = await _context.Tables
                .Where(t => t.Seats >= guests)
                .Where(t => !t.Bookings.Any(b =>
                b.BookingTime < bookingEnd &&
                b.BookingTime.AddHours(2) > bookingStart))
                .ToListAsync();
            return availableTables;
        }

        public async Task<Table> GetAvailableTableById(DateTime bookingDate, int guests, int id)
        {
            var bookingStart = bookingDate;
            var bookingEnd = bookingDate.AddHours(2); // Assuming a 2-hour booking duration
            var table = await _context.Tables
                .Where(t => t.TableId == id && t.Seats >= guests)
                .Where(t => !t.Bookings.Any(b =>
                b.BookingTime < bookingEnd &&
                b.BookingTime.AddHours(2) > bookingStart))
                .FirstOrDefaultAsync();
            return table;
        }
    }
}
