using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolVaccinationPortalAPI.DTOs.Auth;
using SchoolVaccinationPortalAPI.Services.Interfaces;

namespace SchoolVaccinationPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequestDto loginRequest)
        {
            var token = _authService.Authenticate(loginRequest);
            if (token == null)
                return Unauthorized(new { message = "Invalid username or password" });

            return Ok(new { Token = token });
        }



    }
}
