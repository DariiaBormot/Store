using System.Collections.Generic;
using System.Linq;
using Autofac;
using AutoMapper;
using CoffeeShopAPI.Config;
using CoffeeShopAPI.Errors;
using CoffeeShopAPI.Extentions;
using CoffeeShopAPI.Middleware;
using CoffeeShopBL.Config;
using CoffeeShopBL.Interfaces;
using CoffeeShopBL.Services;
using CoffeeShopDAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace CoffeeShopAPI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public IContainer ApplicationContainer { get; private set; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<CoffeeShopContext>(x =>
                    x.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<ConnectionMultiplexer>(c => {
                var config = ConfigurationOptions.Parse(_configuration.GetConnectionString("Redis"),
                    true);
                return ConnectionMultiplexer.Connect(config);
            });
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .SelectMany(x => x.Value.Errors)
                    .Select(x => x.ErrorMessage).ToArray();

                    var errorResponce = new ValidationErrorResponce
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponce);
                };
            });

            services.AddSwaggerDocumentation();

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));



        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Register your own things directly with Autofac
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<ProductTypeService>().As<IProductTypeService>();
            builder.RegisterType<BasketService>().As<IBasketService>();
            builder.RegisterModule<AutofacConfigBL>();

            var config = new MapperConfiguration(cfg => cfg.AddProfiles(
                        new List<Profile>() { new AutomapperProfileWebAPI(), new AutomapperProfileBL() }));

            builder.Register(c => config.CreateMapper());

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseSwaggerDocumentation();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}
