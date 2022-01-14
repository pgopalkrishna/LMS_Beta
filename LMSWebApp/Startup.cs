using LMSDAL;
using LMSService.Services;
using LMSService.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSWebApp
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
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("LMSIdentityContextConnection")));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IOrganizationRepository), typeof(OrganizationRepository));
            services.AddTransient(typeof(ILeaveTypeRepository), typeof(LeaveTypeRepository));
            services.AddTransient(typeof(IEmployeeRepository), typeof(EmployeeRepository));

            services.AddTransient(typeof(IWorkLocationRepository), typeof(WorkLocationRepository));
            services.AddTransient(typeof(IDesignationRepository), typeof(DesignationRepository));
            services.AddTransient(typeof(ILeaveRuleRepository), typeof(LeaveRuleRepository));
            //services.AddTransient(typeof(IOrganizationRepository), typeof(OrganizationRepository));
            //services.AddTransient(typeof(IOrganizationRepository), typeof(OrganizationRepository));
            //services.AddTransient(typeof(IOrganizationRepository), typeof(OrganizationRepository));
            //services.AddTransient(typeof(IOrganizationRepository), typeof(OrganizationRepository));
            //services.AddTransient(typeof(IOrganizationRepository), typeof(OrganizationRepository));

            services.AddControllersWithViews();
            services.AddRazorPages();
            
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
