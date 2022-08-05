using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Design;


using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyVidly.Models.Context;
using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Identity;


using MyVidly.Data.IRepository;
using MyVidly.Data.Repository;
using MyVidly.Settings;
using MyVidly.Data.IServices;
using MyVidly.Data.Services;

namespace MyVidly
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
            services.AddControllersWithViews();
            services.AddMvc();
            services.AddAutoMapper(typeof(AutoMapperProfiles));
            services.AddScoped<ISkillServices, SkillServices>();


            services.AddScoped<IProjectServices, ProjectServices>();
            services.AddScoped<IExperienceServices, ExperienceServices>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IExperienceRepository, ExperienceRepository>();
            services.AddScoped<ISkillServices, SkillServices>();
            services.AddAutoMapper(typeof(Program));
         


            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<MyVidlyDbContext>();    
            services.AddDbContext<MyVidlyDbContext>(item => item.UseSqlServer(Configuration.GetConnectionString("MyConn")));
            services.Configure<IdentityOptions>(opt =>
            {
                opt.Password.RequiredLength = 5;
                opt.Password.RequireLowercase = true;
              /*  opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(20);
                opt.Lockout.MaxFailedAccessAttempts = 2;*/
              /*  opt.SignIn.RequireConfirmedAccount = true;
                opt.SignIn.RequireConfirmedAccount = true;*/




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
              
            app.UseRouting();
            app.UseAuthentication();    

            app.UseAuthorization();

            

            app.UseEndpoints(endpoints =>
            {
                //using attribute routing, to be completed in the action methods
                endpoints.MapControllers(); 
                //using conventional routing

              /*  endpoints.MapControllerRoute("MoviesByReleaseDate",
                    "movies/released/{year}/{month}",
                    new { controller = "Movie", action = "ByReleaseDate" },
                    new { year = @"2015|2016", month = @"\d{2}"}
            );*/
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
