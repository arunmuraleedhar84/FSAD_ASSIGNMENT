using SchoolVaccinationPortalAPI.DTOs.Vaccination;
using SchoolVaccinationPortalAPI.Models;

namespace SchoolVaccinationPortalAPI.Services.Interfaces
{
    public interface IVaccinationService
    {
        Task<IEnumerable<VaccinationRecord>> GetAllVaccinationsAsync();
        Task<VaccinationRecord> MarkStudentVaccinatedAsync(VaccinationRecordDto vaccinationRecordDto);

    }
}
