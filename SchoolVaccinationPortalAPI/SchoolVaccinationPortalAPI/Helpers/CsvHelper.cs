using CsvHelper;
using SchoolVaccinationPortalAPI.DTOs.Student;
using System.Globalization;

namespace SchoolVaccinationPortalAPI.Helpers
{
    public class CsvUploadHelper
    {
        public static async Task<List<StudentDto>> ParseStudentCsv(IFormFile file)
        {
            var students = new List<StudentDto>();

            using (var stream = new StreamReader(file.OpenReadStream()))
            using (var csv = new CsvReader(stream, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<StudentDto>();
                students = records.ToList();
            }

            return students;
        }

    }
}
