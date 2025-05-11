namespace SchoolVaccinationPortalAPI.DTOs.Drive
{
    public class UpcomingDriveDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ApplicableClasses { get; set; } = string.Empty;
        public string VaccineName { get; set; } = string.Empty;
    }
}
