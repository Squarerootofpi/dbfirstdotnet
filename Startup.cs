using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dbfirstdotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace dbfirstdotnet
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
            Console.WriteLine("Setting up db context");
            services.AddDbContext<BowlingLeagueDbContext>(options =>
            options.UseSqlite(Configuration["ConnectionStrings:BowlingLeagueDbConnection"]));
            services.AddScoped<IBowlingLeagueRepository, EFBowlingLeagueRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Console.WriteLine("In configure");
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

            app.UseAuthorization();
            Console.WriteLine("Setting up endpoints:");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "teampage",
                    "{teamid}/{pageNum:int}",
                    new { Controller = "Home", action = "Index" });
                endpoints.MapControllerRoute(
                    "page",
                    "all/{pageNum:int}",
                    new { Controller = "Home", action = "Index" });
                endpoints.MapControllerRoute(
                    "teamid",
                    "{teamid}",
                    new { Controller = "Home", action = "Index", page = 1 });
                endpoints.MapControllerRoute(
                    "pagination",
                    "P{pageNum}",
                    new { Controller = "Home", action = "Index" });
                endpoints.MapDefaultControllerRoute();

            });
        }
    }
}
