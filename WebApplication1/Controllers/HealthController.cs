using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("health")]
    public class HealthController(HealthCheckService healthCheckService) : ControllerBase
    {
        /// <summary>
        /// Returns the health status of the application and database.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var report = await healthCheckService.CheckHealthAsync();

            var result = new
            {
                status = report.Status.ToString(),
                results = report.Entries.Select(e => new {
                    key = e.Key,
                    status = e.Value.Status.ToString(),
                    description = e.Value.Description
                })
            };

            return Ok(result);
        }
    }
}
