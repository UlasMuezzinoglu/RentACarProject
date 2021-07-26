using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Autofac, Ninject, CastleWindsor, StructurMap, LightInject, DryInject --> IoC Container
            //AOP --> bir metotun önünde sonunda hata verdiðinde çalýþan kod parçacýklarý
            services.AddControllers();


            //BU IoC Yapýsý Business da Autofac'e Çekildi
            // For Brand Service
               //services.AddSingleton<IBrandService,BrandManager>();
               //services.AddSingleton<IBrandDal, EfBrandDal>();
            // For Color Service
               //services.AddSingleton<IColorService, ColorManager>();
               //services.AddSingleton<IColorDal, EfColorDal>();
            // For Car Service
                //services.AddSingleton<ICarService, CarManager>();
                //services.AddSingleton<ICarDal, EfCarDal>();
            // For User Service
                //services.AddSingleton<IUserService, UserManager>();
                //services.AddSingleton<IUserDal, EfUserDal>();
            // For Customer Service
                //services.AddSingleton<ICustomerService, CustomerManager>();
                //services.AddSingleton<ICustomerDal, EfCustomerDal>();
            // For Rental Service
                //services.AddSingleton<IRentalService, RentalManager>();
                //services.AddSingleton<IRentalDal, EfRentalDal>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
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
