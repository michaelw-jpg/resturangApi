using Microsoft.EntityFrameworkCore;
using resturangApi.Data;
using resturangApi.Models;
using resturangApi.Repositories.Interface;

namespace resturangApi.Repositories
{
    public class UserRepository(ResturangApiDbContext context) : IUserRepository
    {
        private readonly ResturangApiDbContext _context = context;

        public async Task<User> GetUserByName(string name)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Name == name);
        }
    }
}
