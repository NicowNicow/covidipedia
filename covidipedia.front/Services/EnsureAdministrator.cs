using covidipedia.front.Data;
using covidipedia.front.src.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace covidipedia.front.Services
{
    public class EnsureAdministrator : IHostedService
    {
        // We need to inject the IServiceProvider so we can create the scoped service, ApplicationDbContext
        private readonly IServiceProvider _serviceProvider;
        public EnsureAdministrator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            // Create a new scope to retrieve scoped services
            using var scope = _serviceProvider.CreateScope();
            // Get the DbContext instance
            var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            //Add Administrator if not found
            string adminLoginName = "Administrator";
            int adminId = await applicationDbContext.AppUsers
                .AsNoTracking()
                .Where(a => a.LoginNameUppercase == adminLoginName.ToUpper())
                .Select(a => a.Id)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            if (adminId == 0)
            {
                var password = "P@ssw0rd";
                var adminUser = new AppUser
                {
                    LoginName = adminLoginName,
                    LoginNameUppercase = adminLoginName.ToUpper(),
                    Password = password
                };

                applicationDbContext.AppUsers.Add(adminUser);
                try
                {
                    applicationDbContext.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw new InvalidOperationException($"DbUpdateConcurrencyException occurred creating new admin user in EnsureAdminHostedService.cs.");
                }
                catch (DbUpdateException)
                {
                    throw new InvalidOperationException($"DbUpdateException occurred creating new admin user in EnsureAdminHostedService.cs.");
                }
            }
        }

        // noop
        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
