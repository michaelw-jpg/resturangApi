using Microsoft.EntityFrameworkCore;
using resturangApi.Data;
using resturangApi.Models;
using resturangApi.Repositories.Interface;

namespace resturangApi.Repositories
{
    public class MenuRepository(ResturangApiDbContext context) : IMenuRepository
    {
        private readonly ResturangApiDbContext _context = context;

        public async Task<List<Menu>> GetAllMenusAsync()
        {
            
            var menuItems = await _context.Menus.ToListAsync();
            return menuItems;
        }
        public async Task<Menu> GetMenuByIdAsync(int id)
        {
            // Implementation for fetching a menu by its ID
            try
            {
                var menuItem = await _context.Menus.FindAsync(id);
                return menuItem;
            }
            catch (Exception)
            {

                throw;
            }
            
            
        }
        public Task<Menu> CreateMenuAsync(Menu menu)
        {
            // Implementation for creating a new menu
            throw new NotImplementedException();
        }
        public Task<Menu> UpdateMenuAsync(Menu menu)
        {
            // Implementation for updating an existing menu
            throw new NotImplementedException();
        }
        public Task<bool> DeleteMenuAsync(int id)
        {
            // Implementation for deleting a menu by its ID
            throw new NotImplementedException();
        }
    }
}
