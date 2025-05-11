using SchoolVaccinationPortalAPI.DTOs.Student;
using SchoolVaccinationPortalAPI.Models;

namespace SchoolVaccinationPortalAPI.Services.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task<Student> AddStudentAsync(StudentDto studentDto);
        Task<Student> UpdateStudentAsync(int id, StudentDto studentDto);
        Task<bool> DeleteStudentAsync(int id);
        Task<int> BulkUploadStudentsAsync(List<StudentDto> students);

    }
}
