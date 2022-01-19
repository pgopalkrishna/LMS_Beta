using System;
using LMSWebApp.Areas.Identity.Data;
using LMSWebApp.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(LMSWebApp.Areas.Identity.IdentityHostingStartup))]
namespace LMSWebApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<LMSIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("LMSIdentityContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<LMSIdentityContext>();
            });
        }
    }
}