
using ECommerce.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce
{
    public class Program
    {
        public static async Task  Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configurations
            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            #endregion

            var app = builder.Build();

            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var dbContext = services.GetRequiredService<AppDbContext>();
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                await dbContext.Database.MigrateAsync();
            }
            catch (Exception ex) {
              var logger =  loggerFactory.CreateLogger<Program>();
                logger.LogError(ex.Message+ "SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS");
            
            }

            #region MiddelWare
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            #endregion


            app.Run();
        }
    }
}
