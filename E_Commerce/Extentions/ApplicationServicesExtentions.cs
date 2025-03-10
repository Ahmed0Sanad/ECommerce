using E_Commerce.Helper;
using ECommerce.Core.Repository.Contract;
using ECommerce.Repository.Data;
using ECommerce.Repository;
using Microsoft.AspNetCore.Mvc;
using E_Commerce.Errors;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using ECommerce.Repository.Identity;
using ECommerce.Core.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using ECommerce.Core.Services.Contract;
using ECommerce.Services;
using ECommerce.Core;

namespace E_Commerce.Extentions
{
    public static class ApplicationServicesExtentions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration Configuration)
        {
            #region connection Strings
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddDbContext<IdentityDataBase>(options => options.UseSqlServer(Configuration.GetConnectionString("Identity")));
            // redis
            services.AddSingleton<IConnectionMultiplexer>((ServiceProveder) =>
            {
                string connectionString = Configuration.GetConnectionString("redis");
                return ConnectionMultiplexer.Connect(connectionString);
            });
            #endregion

            #region LifeTime
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddSingleton<IBasketRepository, BasketRepository>();
            //services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IOrderService), typeof(OrderService));
            #endregion

            //services.AddAutoMapper(typeof(MappingProfile));
            services.AddAutoMapper(M => M.AddProfile(new MappingProfile(Configuration["ApiBaseUrl"])));
            //Error handle
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
            //use Identity
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<IdentityDataBase>();
           
            return services;


        }
    }
}
