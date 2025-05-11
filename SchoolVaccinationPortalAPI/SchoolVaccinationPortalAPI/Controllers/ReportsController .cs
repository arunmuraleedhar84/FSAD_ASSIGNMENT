using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolVaccinationPortalAPI.Services.Interfaces;

namespace SchoolVaccinationPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        // GET: api/reports/vaccination
        [HttpGet("vaccination")]
        public async Task<IActionResult> GetVaccinationReport()
        {
            try
            {
                // Fetch vaccination report data from service layer
                var reportData = await _reportService.GetVaccinationReport();
                return Ok(reportData);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
