using System.ComponentModel.DataAnnotations;

namespace SchoolVaccinationPortalAPI.DTOs.Drive
{

    public class VaccinationDriveDto
    {
        public string DriveName { get; set; }
        public DateTime Date { get; set; }
        public int VaccineId { get; set; }
        public string ApplicableClasses { get; set; } // e.g., "1A,2B"
        public int AvailableDoses { get; set; }
    }
}
