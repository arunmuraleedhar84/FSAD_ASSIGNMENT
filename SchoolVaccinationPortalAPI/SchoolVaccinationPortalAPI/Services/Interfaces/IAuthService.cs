using SchoolVaccinationPortalAPI.DTOs.Auth;

namespace SchoolVaccinationPortalAPI.Services.Interfaces
{
    public interface IAuthService
    {
        string Authenticate(LoginRequestDto loginRequest);
    }
}
