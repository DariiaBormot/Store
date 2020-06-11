using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using CoffeeShopAPI.Config;
using CoffeeShopBL.Config;
using CoffeeShopBL.Interfaces;
using CoffeeShopBL.Services;
using CoffeeShopDAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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

        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Register your own things directly with Autofac
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<ProductTypeService>().As<IProductTypeService>();
            builder.RegisterModule<AutofacConfigBL>();


            var config = new MapperConfiguration(cfg => cfg.AddProfiles(
                        new List<Profile>() { new AutomapperProfileWebAPI(), new AutomapperProfileBL() }));

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

            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}
