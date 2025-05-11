using SchoolVaccinationPortalAPI.Models;

namespace SchoolVaccinationPortalAPI.Data
{
    public class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Check if any users exist
            if (context.Users.Any())
            {
                return; // DB has already been seeded
            }

            // Seed a default coordinator user
            var user = new User
            {
                Username = "coordinator",
                Password = "password123", // Password is configured plane text , we may encrypt it or hash it for ensuring more seurity
                Role = "Coordinator"
            };

            context.Users.Add(user);
            context.SaveChanges();
        }

    }
}
