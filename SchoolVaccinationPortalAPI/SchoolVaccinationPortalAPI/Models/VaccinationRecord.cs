namespace SchoolVaccinationPortalAPI.Models
{
    public class VaccinationRecord
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int DriveId { get; set; }
        public DateTime VaccinationDate { get; set; }
        public bool Vaccinated { get; set; }


    }
}
