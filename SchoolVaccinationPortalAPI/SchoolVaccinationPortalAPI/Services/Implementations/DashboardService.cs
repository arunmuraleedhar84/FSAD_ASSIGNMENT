using Microsoft.EntityFrameworkCore;
using SchoolVaccinationPortalAPI.Data;
using SchoolVaccinationPortalAPI.DTOs.Dashboard;
using SchoolVaccinationPortalAPI.DTOs.Drive;
using SchoolVaccinationPortalAPI.Services.Interfaces;

namespace SchoolVaccinationPortalAPI.Services.Implementations
{
    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext _context;

        public DashboardService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DashboardDataDto> GetDashboardSummaryAsync()
        {
            var totalStudents = await _context.Students.CountAsync();

            var vaccinatedStudentIds = await _context.VaccinationRecords
                .Where(r => r.Vaccinated)
                .Select(r => r.StudentId)
                .Distinct()
                .ToListAsync();

            var vaccinatedCount = vaccinatedStudentIds.Count;

            var upcomingDrivesQuery = _context.VaccinationDrives
                .Where(d => d.Date > DateTime.UtcNow)
                .OrderBy(d => d.Date)
                .Select(d => new UpcomingDriveDto
                {
                    Id = d.Id,
                    Date = d.Date,
                    ApplicableClasses = d.ApplicableClasses,
                    VaccineName = _context.Vaccines
                        .Where(v => v.Id == d.VaccineId)
                        .Select(v => v.Name)
                        .FirstOrDefault() ?? ""
                });

            var upcomingDrives = await upcomingDrivesQuery.ToListAsync();
            double vaccinationPercentage = 0;

            if (totalStudents > 0)
                vaccinationPercentage = Math.Round((double)vaccinatedCount / totalStudents * 100, 2);




            return new DashboardDataDto
            {
                TotalStudents = totalStudents,
                VaccinatedStudents = vaccinatedCount,
                VaccinationPercentage = vaccinationPercentage,
                UpcomingDrivesCount = upcomingDrives.Count(),
                NextUpcomingDriveDate = upcomingDrivesQuery.FirstOrDefault()?.Date
            };
        }

    }
}
