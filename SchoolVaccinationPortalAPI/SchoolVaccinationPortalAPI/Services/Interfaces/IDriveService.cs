using SchoolVaccinationPortalAPI.DTOs.Drive;
using SchoolVaccinationPortalAPI.Models;

namespace SchoolVaccinationPortalAPI.Services.Interfaces
{

    public interface IDriveService
    {
        Task<List<VaccinationDrive>> GetAllAsync();
        Task<VaccinationDrive?> GetByIdAsync(int id);
        Task<bool> CreateAsync(VaccinationDriveDto dto);
        Task<bool> UpdateAsync(int id, VaccinationDriveDto dto);
    }
}

