using resturangApi.Models;
using resturangApi.Repositories.Interface;
using resturangApi.Services.Iservices;

namespace resturangApi.Services
{
    public class TableService(ITableRepository repo) : ITableService
    {
        private readonly ITableRepository _repo = repo;

        public async Task<List<Table>> GetAllAvailableTables(DateTime bookingDate, int guests)
        {
            var availableTables = await _repo.GetAllAvailableTables(bookingDate, guests);

            return availableTables;
        }
        public async Task<Table> GetAvailableTableById(DateTime bookingDate, int guests,int id)
        {
            var availableTables = await _repo.GetAvailableTableById(bookingDate, guests,id);

            return availableTables;
        }
    }
}
