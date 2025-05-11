namespace SchoolVaccinationPortalAPI.DTOs.Report
{
    public class VaccinationReportDto
    {
        public string StudentName { get; set; }
        public string ClassName { get; set; }
        public string Section { get; set; }
        public string GuardianName { get; set; }
        public string VaccineName { get; set; }
        public DateTime VaccinationDate { get; set; }
        public bool Vaccinated { get; set; }

    }

  
}
