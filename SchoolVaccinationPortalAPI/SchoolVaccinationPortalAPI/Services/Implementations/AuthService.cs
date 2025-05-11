using SchoolVaccinationPortalAPI.Data;
using SchoolVaccinationPortalAPI.DTOs.Auth;
using SchoolVaccinationPortalAPI.Helpers;
using SchoolVaccinationPortalAPI.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;

namespace SchoolVaccinationPortalAPI.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public string Authenticate(LoginRequestDto loginRequest)
        {
            // Simulate checking a user (hardcoded user can also be seeded)
            var user = _context.Users
                .FirstOrDefault(u => u.Username == loginRequest.Username && u.Password == loginRequest.Password);

            if (user == null) return null;

            // Generate JWT Token
            return JwtHelper.GenerateJwtToken(user);
        }

    }
}
