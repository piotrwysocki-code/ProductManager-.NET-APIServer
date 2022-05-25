using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PW_Assignment_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PW_Assignment_3
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
            services.AddDbContext<Site_DBContext>(opt =>
            {
                opt.UseSqlServer(Configuration["ConnectionStrings:BSConn"]);
            }
            );
            services.AddScoped<IProductRepo, ProductRepository>();
            services.AddScoped<ICategoryRepo, CategoryRepository>();
            services.AddRazorPages();
            services.AddControllersWithViews().AddNewtonsoftJson(); 
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("Version1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "V1",
                    Title = "Assignment 3 PW",
                    TermsOfService = new System.Uri("https://sheridancollege.ca"),
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Piotr Wysocki",
                        Email = "wysockpi@sheridancollege.ca",
                        Url = new System.Uri("https://sheridancollege.ca")
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "Piotr Wysocki"
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/Version1/swagger.json", "Product and Category Api Document");
            });
            app.UseRouting();
            app.UseSwagger();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
