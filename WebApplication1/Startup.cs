using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Students.Data;

namespace DutchTreat
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StudentContext>(cfg =>
            {
                cfg.UseSqlServer(_config.GetConnectionString("StudentContextDb"));
            });



            services.AddTransient<StudentSeeder>();

            services.AddScoped<IStudentRepository, StudentRepository>();

            //services.AddTransient<IMailService, NullMailService>();
            // Support for real mail service

            services.AddControllersWithViews();

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc(
                    "StudentOpenAPI",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Student API",
                        Version = "1"
                    });
                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
                setupAction.IncludeXmlComments(xmlCommentsFullPath);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint(
                    "/swagger/StudentOpenAPI/swagger.json",
                    "Student API");
            });

            app.UseStaticFiles();


            app.UseRouting();

            app.UseEndpoints(cfg =>
            {
                cfg.MapControllerRoute("Default",
                      "{controller}/{action}/{id?}",
                      new { controller = "Student", Action = "Index" });
            });

        }
    }
}
