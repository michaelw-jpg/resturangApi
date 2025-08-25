using resturangApi.Models;

namespace resturangApi.Repositories.Interface
{
    public interface IBookingRepository
    {

        Task<List<Booking>> GetOldBookingsForGDPR(DateTime cutoffDate);
    }
}
