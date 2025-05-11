using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolVaccinationPortalAPI.DTOs.Vaccination;
using SchoolVaccinationPortalAPI.Services.Interfaces;

namespace SchoolVaccinationPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VaccinationRecordsController : ControllerBase
    {
        private readonly IVaccinationService _vaccinationService;

        public VaccinationRecordsController(IVaccinationService vaccinationService)
        {
            _vaccinationService = vaccinationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVaccinations()
        {
            var vaccinations = await _vaccinationService.GetAllVaccinationsAsync();
            return Ok(vaccinations);
        }

        [HttpPost]
        public async Task<IActionResult> MarkStudentVaccinated([FromBody] VaccinationRecordDto vaccinationRecordDto)
        {
            var record = await _vaccinationService.MarkStudentVaccinatedAsync(vaccinationRecordDto);
            return Ok(record);
        }

    }
}
