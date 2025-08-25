using resturangApi.Dto.BookingDtos;
using resturangApi.Models;
using resturangApi.Repositories.Interface;
using resturangApi.Services.Iservices;

namespace resturangApi.Services
{
    public class BookingService(IGenericItemService genService, IGenericRepository genRepo
        ,ITableService tableService, IBookingRepository bookingRepo) : IBookingService
    {
        private readonly IGenericItemService _genService = genService;
        private readonly IGenericRepository _genRepo = genRepo;
        private readonly ITableService _tableService = tableService;
        private readonly IBookingRepository _bookingRepo = bookingRepo;
        public async Task<Booking> CreateBookingAsync(CreateBookingDto dto)
        {
            var customer = await _genRepo.GetItemByID<Customer>(dto.CustomerId_FK);
            if (customer == null)
            {
                //probably need to change to return error code with message
                throw new ArgumentException("Invalid CustomerId_FK");
            }

            var tableavilability = await _tableService.GetAvailableTableById(dto.BookingTime, dto.Guests, dto.TableId_FK);

            if (tableavilability == null)
            {
                //probably need to change to return error code with message
                throw new ArgumentException("Table is not available at the requested time or does not exist");
            }

            var booking = await _genService.CreateItem<Booking, CreateBookingDto>(dto);
            return booking;
        }

        public async Task<List<Booking>> GetOldBookingsForGDPR(DateTime cutOffDate)
        {
            var result = await  _bookingRepo.GetOldBookingsForGDPR(cutOffDate);
            return result;
        }
    }
}
