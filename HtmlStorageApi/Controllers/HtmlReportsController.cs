using HtmlStorageApi.Models;
using HtmlStorageApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HtmlStorageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HtmlReportsController : ControllerBase
    {
        private readonly HtmlReportService _htmlReportService;

        public HtmlReportsController(HtmlReportService htmlReportService)
        {
            _htmlReportService = htmlReportService;
        }

        // POST: api/htmlreports
        [HttpPost]
        public async Task<IActionResult> SaveHtmlReport([FromBody] HtmlReport report)
        {
            var exists = await _htmlReportService.ReportExistsAsync(report.ReportId);
            if (exists)
            {
                return BadRequest("Report already exists.");
            }

            await _htmlReportService.CreateAsync(report);
            return Ok("Report saved successfully.");
        }

        // GET: api/htmlreports/{reportId}
        [HttpGet("{reportId}")]
        public async Task<IActionResult> GetHtmlReport(string reportId)
        {
            var report = await _htmlReportService.GetByReportIdAsync(reportId);
            if (report == null)
            {
                return NotFound();
            }

            return Ok(report.HtmlContent);
        }

        // GET: api/htmlreports/check/{reportId}
        [HttpGet("check/{reportId}")]
        public async Task<IActionResult> CheckReportExists(string reportId)
        {
            var exists = await _htmlReportService.ReportExistsAsync(reportId);
            return Ok(exists);
        }
    }
}
