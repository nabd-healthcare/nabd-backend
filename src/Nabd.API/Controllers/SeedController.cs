using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nabd.Shared.Extensions;

namespace Nabd.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeedController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;

        public SeedController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpPost("seed")]
        public async Task<IActionResult> SeedDatabase()
        {
            try
            {
                await DatabaseSeederExtension.SeedDatabaseAsync(HttpContext.RequestServices.GetRequiredService<IApplicationBuilder>());
                return Ok(new { message = "Database seeded successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Seeding failed", error = ex.Message, stackTrace = ex.StackTrace });
            }
        }

        [HttpPost("clear")]
        public async Task<IActionResult> ClearDatabase()
        {
            try
            {
                await DatabaseSeederExtension.ClearDatabaseAsync(HttpContext.RequestServices.GetRequiredService<IApplicationBuilder>());
                return Ok(new { message = "Database cleared successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Clearing failed", error = ex.Message, stackTrace = ex.StackTrace });
            }
        }
    }
}
