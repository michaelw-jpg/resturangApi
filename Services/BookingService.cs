using resturangApi.Dto.BookingDtos;
using resturangApi.Models;
using resturangApi.Repositories.Interface;
using resturangApi.Services.Iservices;

namespace resturangApi.Services
{
    public class BookingService(IGenericItemService genService
        ,ITableService tableService, IBookingRepository bookingRepo) : IBookingService
    {
        private readonly IGenericItemService _genService = genService;
        private readonly ITableService _tableService = tableService;
        private readonly IBookingRepository _bookingRepo = bookingRepo;
        public async Task<Booking> CreateBookingAsync(CreateBookingDto dto)
        {
           

            var tableavilability = await _tableService.GetAvailableTableById(dto.BookingTime, dto.Guests, dto.TableId_FK);

            if (tableavilability == null)
            {
                //probably need to change to return error code with message
               return null;
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
