namespace SchoolVaccinationPortalAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string GuardianName { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty; // Ex: "Grade 5"
        public string Section { get; set; } = string.Empty;     // e.g., "A", "B"
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }

    }
}
