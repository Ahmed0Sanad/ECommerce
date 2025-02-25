using ECommerce.Core.Entity.Identity;
using ECommerce.Repository.Data;
using ECommerce.Repository.Identity;
using Microsoft.AspNetCore.Identity;
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
            var IdentityContext = services.GetRequiredService<IdentityDataBase>();
            var userManager = services.GetRequiredService<UserManager<AppUser>>();
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                await dbContext.Database.MigrateAsync();
                Seeding.SeedingHelper(dbContext);

                await IdentityContext.Database.MigrateAsync();
                await IdentitySeeding.Seed(userManager);
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex.Message);

            }

        }

    }
}
