using resturangApi.Models;

namespace resturangApi.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<User> GetUserByName(string name);
    }
}
