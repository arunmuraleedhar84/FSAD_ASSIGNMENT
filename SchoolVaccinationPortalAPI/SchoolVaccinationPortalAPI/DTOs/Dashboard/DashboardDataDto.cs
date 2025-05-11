using SchoolVaccinationPortalAPI.DTOs.Drive;

namespace SchoolVaccinationPortalAPI.DTOs.Dashboard
{
    public class DashboardDataDto
    {
        public int TotalStudents { get; set; }
        public int VaccinatedStudents { get; set; }
        public double VaccinationPercentage { get; set; }
        public int UpcomingDrivesCount { get; set; }
        public DateTime? NextUpcomingDriveDate { get; set; }
        public VaccinationDriveDto? UpcomingDrive { get; set; }
    }
}

