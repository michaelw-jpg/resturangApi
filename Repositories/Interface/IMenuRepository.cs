using resturangApi.Models;

namespace resturangApi.Repositories.Interface
{
    public interface IMenuRepository
    {
        Task<List<Menu>> GetAllMenusAsync();
        Task<Menu> GetMenuByIdAsync();
        Task<Menu> CreateMenuAsync(Menu menu);
        Task<Menu> UpdateMenuAsync(Menu menu);
        Task<bool> DeleteMenuAsync(int id);
       
    }
}
