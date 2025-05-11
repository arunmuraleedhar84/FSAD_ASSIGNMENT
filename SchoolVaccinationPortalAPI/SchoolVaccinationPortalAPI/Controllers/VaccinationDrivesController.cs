using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolVaccinationPortalAPI.DTOs.Drive;
using SchoolVaccinationPortalAPI.Models;
using SchoolVaccinationPortalAPI.Services.Interfaces;

namespace SchoolVaccinationPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VaccinationDrivesController : ControllerBase
    {
        private readonly IDriveService _driveService;

        public VaccinationDrivesController(IDriveService driveService)
        {
            _driveService = driveService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VaccinationDrive>>> GetAll()
        {
            return Ok(await _driveService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VaccinationDriveDto>> Get(int id)
        {
            return Ok(await _driveService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VaccinationDriveDto dto)
        {

            try
            {
                if (dto.AvailableDoses <= 0)
                    return BadRequest(new { message = "Available doses must be greater than zero." });

                if (dto.Date == default)
                    return BadRequest(new { message = "Drive date must be provided." });

                if (string.IsNullOrWhiteSpace(dto.ApplicableClasses))
                    return BadRequest(new { message = "Applicable classes must be specified." });

                var result = await _driveService.CreateAsync(dto);
                if (result)
                    return Ok(new { message = "Vaccination drive created successfully." });
                else
                    return BadRequest(new { message = "Drive creation failed." }); // fallback
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message }); // e.g., "Invalid VaccineId"
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "An unexpected error occurred while creating the drive." });
            }
           
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] VaccinationDriveDto dto)
        {
            await _driveService.UpdateAsync(id, dto);
            return NoContent();
        }

    }
}
