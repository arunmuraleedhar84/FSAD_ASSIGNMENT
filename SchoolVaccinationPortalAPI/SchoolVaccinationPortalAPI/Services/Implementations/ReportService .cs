using SchoolVaccinationPortalAPI.Data;
using SchoolVaccinationPortalAPI.DTOs.Report;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SchoolVaccinationPortalAPI.Services.Interfaces;

namespace SchoolVaccinationPortalAPI.Services.Implementations
{
    public class ReportService : IReportService
    {
        private readonly ApplicationDbContext _context; 

        public ReportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<VaccinationReportDto>> GetVaccinationReport()
        {
            var report = await (from record in _context.VaccinationRecords
                                join student in _context.Students on record.StudentId equals student.Id
                                join drive in _context.VaccinationDrives on record.DriveId equals drive.Id
                                join vaccine in _context.Vaccines on drive.VaccineId equals vaccine.Id
                                select new VaccinationReportDto
                                {
                                    StudentName = student.FullName,
                                    ClassName = student.ClassName,
                                    Section = student.Section,
                                    GuardianName = student.GuardianName,
                                    VaccineName = vaccine.Name,
                                    VaccinationDate = record.VaccinationDate,
                                    Vaccinated = record.Vaccinated
                                }).ToListAsync();

            return report;
        }

    }
}



