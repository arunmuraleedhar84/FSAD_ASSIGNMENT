namespace SchoolVaccinationPortalAPI.DTOs.Drive
{
    public class VaccinationRecordDto
    {
        public int StudentId { get; set; }
        public int DriveId { get; set; }
        public DateTime VaccinationDate { get; set; }
        public bool Vaccinated { get; set; }

    }
}
