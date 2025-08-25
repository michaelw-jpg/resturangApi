using resturangApi.Models;

namespace resturangApi.Repositories.Interface
{
    public interface ITableRepository
    {
        Task<List<Table>> GetAllAvailableTables(DateTime bookingDate, int guests);

        Task<Table> GetAvailableTableById(DateTime bookingDate, int guests, int id);
    }
}
