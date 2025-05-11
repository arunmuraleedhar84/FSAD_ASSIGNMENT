namespace SchoolVaccinationPortalAPI.Models
{
    public class VaccinationDrive
    {
        public int Id { get; set; }
        public string DriveName { get; set; }
        public DateTime Date { get; set; }
        public string ApplicableClasses { get; set; } // comma-separated
        public int VaccineId { get; set; }
        public int AvailableDoses { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public Vaccines Vaccine { get; set; } // Navigation property
    }
}
