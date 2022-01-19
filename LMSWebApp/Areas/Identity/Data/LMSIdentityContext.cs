using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMSWebApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LMSWebApp.Data
{
    public class LMSIdentityContext : IdentityDbContext<ApplicationUser>
    {
        public LMSIdentityContext(DbContextOptions<LMSIdentityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "ReportingMgr", NormalizedName = "ReportingMgr".ToUpper() });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "User", NormalizedName = "User".ToUpper() });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "SuperAdmin", NormalizedName = "SuperAdmin".ToUpper() });
        }
    }
}
