using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolVaccinationPortalAPI.DTOs.Student;
using SchoolVaccinationPortalAPI.Services.Interfaces;
using SchoolVaccinationPortalAPI.Helpers;
using Swashbuckle.AspNetCore.Annotations;

namespace SchoolVaccinationPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentsController : ControllerBase
    {

        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentDto studentDto)
        {
            var student = await _studentService.AddStudentAsync(studentDto);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentDto studentDto)
        {
            var updatedStudent = await _studentService.UpdateStudentAsync(id, studentDto);
            if (updatedStudent == null) return NotFound();
            return Ok(updatedStudent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _studentService.DeleteStudentAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpPost("bulk-upload")]
                [Consumes("multipart/form-data")]
        public async Task<IActionResult> BulkUploadStudents([FromForm] BulkUploadDto file)
        {
            //[FromForm] IFormFile StudentFile
            //[FromForm]BulkUploadDto file
            var students = await CsvUploadHelper.ParseStudentCsv(file.StudentFile);
            
            var count = await _studentService.BulkUploadStudentsAsync(students);
            return Ok(new { message = $"{count} students uploaded successfully." });
        }

    }
}
