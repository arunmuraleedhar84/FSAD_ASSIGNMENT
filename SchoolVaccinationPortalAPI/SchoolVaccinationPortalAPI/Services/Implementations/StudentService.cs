using Microsoft.EntityFrameworkCore;
using SchoolVaccinationPortalAPI.Data;
using SchoolVaccinationPortalAPI.DTOs.Student;
using SchoolVaccinationPortalAPI.Models;
using SchoolVaccinationPortalAPI.Services.Interfaces;
using static System.Collections.Specialized.BitVector32;


namespace SchoolVaccinationPortalAPI.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<Student> AddStudentAsync(StudentDto studentDto)
        {
            var student = new Student
            {
                FullName = studentDto.FullName,
                ClassName = studentDto.ClassName,
                GuardianName= studentDto.GuardianName,
                Section = studentDto.Section,
                CreatedTime = DateTime.UtcNow,
                UpdatedTime = DateTime.UtcNow
            };

           
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> UpdateStudentAsync(int id, StudentDto studentDto)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return null;
            }
            else
            {

                student.FullName = studentDto.FullName;
                student.ClassName = studentDto.ClassName;
                student.GuardianName = studentDto.GuardianName;
                student.Section = studentDto.Section;
                student.UpdatedTime = DateTime.UtcNow;
                await _context.SaveChangesAsync();

                return student;

            }
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return false;
            }
            else
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return true;
            }
                
        }

        public async Task<int> BulkUploadStudentsAsync(List<StudentDto> students)
        {
            var studentEntities = students.Select(s => new Student
            {
                FullName = s.FullName,
                ClassName = s.ClassName,
                GuardianName = s.GuardianName,
                Section = s.Section,
                CreatedTime = DateTime.UtcNow,
                UpdatedTime = DateTime.UtcNow
            }).ToList();

            _context.Students.AddRange(studentEntities);
            return await _context.SaveChangesAsync();
        }

    }
}
