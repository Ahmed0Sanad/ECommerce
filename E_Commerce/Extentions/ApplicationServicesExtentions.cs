using E_Commerce.Helper;
using ECommerce.Core.Repository.Contract;
using ECommerce.Repository.Data;
using ECommerce.Repository;
using Microsoft.AspNetCore.Mvc;
using E_Commerce.Errors;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Extentions
{
    public static class ApplicationServicesExtentions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration builder) 
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.GetConnectionString("Default")));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //services.AddAutoMapper(typeof(MappingProfile));
            services.AddAutoMapper(M => M.AddProfile(new MappingProfile(builder["ApiBaseUrl"])));
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(e => e.Value.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToList();

                    var errorResponse = new VaildationErrorResponse(errors);


                    return new BadRequestObjectResult(errorResponse);
                };
            });

            return services;


        }
    }
}
