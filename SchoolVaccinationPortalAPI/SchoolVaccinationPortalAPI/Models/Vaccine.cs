using System.ComponentModel.DataAnnotations;

namespace SchoolVaccinationPortalAPI.Models
{
    public class Vaccines
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
