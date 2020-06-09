using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using CofeeShopDAL;
using CoffeeShop.Config;
using CoffeeShopBL.Config;
using CoffeeShopBL.Interfaces;
using CoffeeShopBL.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;

namespace CoffeeShop
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
            services.AddDbContext<CoffeShopContext>(x => 
                    x.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Register your own things directly with Autofac
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterModule<AutofacConfigBL>();

            var config = new MapperConfiguration(cfg => cfg.AddProfiles(
                        new List<Profile>() { new AutomapperProfileWeb(), new AutomapperProfileBL() }));
                        builder.Register(c => config.CreateMapper());

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
