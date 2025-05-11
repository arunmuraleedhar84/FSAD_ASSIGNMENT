using SchoolVaccinationPortalAPI.DTOs.Drive;
using SchoolVaccinationPortalAPI.Models;

namespace SchoolVaccinationPortalAPI.Services.Interfaces
{
    public interface IVaccineService
    {
        Task<IEnumerable<Vaccines>> GetAllVaccinesAsync();
        Task<Vaccines> CreateVaccineAsync(VaccineDto dto);
    }
}
