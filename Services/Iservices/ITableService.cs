using resturangApi.Models;

namespace resturangApi.Services.Iservices
{
    public interface ITableService
    {
        Task <List<Table>> GetAllAvailableTables(DateTime bookingDate, int guests);
        Task<Table> GetAvailableTableById(DateTime bookingDate, int guests, int id);
    }
}
