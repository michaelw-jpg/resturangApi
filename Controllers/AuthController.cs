using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using resturangApi.Dto.UserDtos;
using resturangApi.Repositories.Interface;
using resturangApi.Services.Iservices;

namespace resturangApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginRequestDto request)
        {
            var response = await _authService.Login(request.Name, request.Password);
            if(response == null)
            {
                return Unauthorized("Invalid username or password");
            }
            return Ok("Login successful");

        }
    }
}
