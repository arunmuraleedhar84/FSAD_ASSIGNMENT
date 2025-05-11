using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolVaccinationPortalAPI.DTOs.Drive;
using SchoolVaccinationPortalAPI.Services.Interfaces;

namespace SchoolVaccinationPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VaccinesController : ControllerBase
    {
        private readonly IVaccineService _vaccineService;

        public VaccinesController(IVaccineService vaccineService)
        {
            _vaccineService = vaccineService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vaccines = await _vaccineService.GetAllVaccinesAsync();
            return Ok(vaccines);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VaccineDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _vaccineService.CreateVaccineAsync(dto);
            return CreatedAtAction(nameof(GetAll), new { id = result.Id }, result);
        }
    }
}
