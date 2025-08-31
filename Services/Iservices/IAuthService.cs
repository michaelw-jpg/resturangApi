using resturangApi.Models;

namespace resturangApi.Services.Iservices
{
    public interface IAuthService
    {
        Task<string> Login(string name, string password);
       
    }
}
