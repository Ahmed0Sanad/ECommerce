using ECommerce.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Extentions
{
    public static class DbPreProcessExtention
    {
        public static async void DbPreProcess(this WebApplication app )
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var dbContext = services.GetRequiredService<AppDbContext>();
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                await dbContext.Database.MigrateAsync();
                Seeding.SeedingHelper(dbContext);
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex.Message);

            }

        }

    }
}
