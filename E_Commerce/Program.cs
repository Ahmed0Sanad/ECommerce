
using E_Commerce.Errors;
using E_Commerce.Helper;
using E_Commerce.Middlewares;
using ECommerce.Core.Repository.Contract;
using ECommerce.Repository;
using ECommerce.Repository.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Commerce.Extentions;

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
            builder.Services.AddApplicationServices(builder.Configuration);
            #endregion

            var app = builder.Build();
            app.DbPreProcess();

            #region MiddelWare
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthorization();
            app.MapControllers();

            #endregion


            app.Run();
        }
    }
}
