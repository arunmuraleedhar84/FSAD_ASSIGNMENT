using SchoolVaccinationPortalAPI.DTOs.Report;

namespace SchoolVaccinationPortalAPI.Services.Interfaces
{
    public interface IReportService
    {
        Task<List<VaccinationReportDto>> GetVaccinationReport();
    }
}
