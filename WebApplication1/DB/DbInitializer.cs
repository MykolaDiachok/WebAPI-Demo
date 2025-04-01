using Microsoft.EntityFrameworkCore;
using WebApplication1.DB;

namespace WebApplication1.Data;

public static class DbInitializer
{
    public static void Initialize(ApplicationDbContext context)
    {
        //context.Database.Migrate();

        if (!context.WeatherForecasts.Any())
        {
            var summaries = new[] { "Freezing", "Warm", "Hot" };
            var forecasts = Enumerable.Range(1, 5).Select(i =>
                new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Today.AddDays(i)),
                    TemperatureC = Random.Shared.Next(-20, 35),
                    Summary = summaries[Random.Shared.Next(summaries.Length)]
                }).ToList();

            context.WeatherForecasts.AddRange(forecasts);
            context.SaveChanges();
        }
    }
}