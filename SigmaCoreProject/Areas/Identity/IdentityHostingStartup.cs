using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SigmaCoreProject.Models;

[assembly: HostingStartup(typeof(SigmaCoreProject.Areas.Identity.IdentityHostingStartup))]
namespace SigmaCoreProject.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SigmaCoreProjectContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("sigmaCoreDB")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<SigmaCoreProjectContext>();
            });
        }
    }
}