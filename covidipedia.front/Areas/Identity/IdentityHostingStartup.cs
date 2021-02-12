using System;
using System.Threading.Tasks;
using covidipedia.front.Areas.Identity.Data;
using covidipedia.front.Data;
using covidipedia.front.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(covidipedia.front.Areas.Identity.IdentityHostingStartup))]
namespace covidipedia.front.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(
                        context.Configuration.GetConnectionString("ApplicationDbContextConnection")));

                
                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

                services.AddHostedService<EnsureAdministrator>();

            });
        }
       
    }
}