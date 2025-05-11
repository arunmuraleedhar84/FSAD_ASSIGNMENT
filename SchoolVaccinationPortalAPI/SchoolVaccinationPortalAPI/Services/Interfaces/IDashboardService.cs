using SchoolVaccinationPortalAPI.DTOs.Dashboard;

namespace SchoolVaccinationPortalAPI.Services.Interfaces
{
    public interface IDashboardService
    {
        
            Task<DashboardDataDto> GetDashboardSummaryAsync();
        
    }
}
