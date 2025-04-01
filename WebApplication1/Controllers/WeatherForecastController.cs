using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DB;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController(ApplicationDbContext db) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await db.WeatherForecasts
                .OrderBy(w => w.Date)
                .Take(5)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Add(WeatherForecast forecast)
        {
            db.WeatherForecasts.Add(forecast);
            await db.SaveChangesAsync();
            return CreatedAtRoute("GetWeatherForecast", new { id = forecast.Id }, forecast);
        }
    }
}
