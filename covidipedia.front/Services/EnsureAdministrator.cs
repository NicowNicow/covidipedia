﻿using covidipedia.front.Data;
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

            string adminLoginName = "Administrator";
            string adminMail = "Administrator@test.com";
            int adminId = await applicationDbContext.AppUsers
                .AsNoTracking()
                .Where(a => a.LoginNameUppercase == adminLoginName.ToUpper())
                .Select(a => a.Id)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            // Reset Administrator after migration
            var resetAdministrator = false;
            if (adminId != 0 && resetAdministrator)
            {
                var admin = await applicationDbContext.AppUsers
                .Where(a => a.Id == adminId)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

                applicationDbContext.AppUsers.Remove(admin);
                try
                {
                    applicationDbContext.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw new InvalidOperationException("DbUpdateConcurrencyException occurred deleting old " +
                        "admin user in EnsureAdminHostedService.cs.");
                }
                catch (DbUpdateException)
                {
                    throw new InvalidOperationException("DbUpdateException occurred deleting old admin user in " +
                       "EnsureAdminHostedService.cs.");
                }

                adminId = 0;
            }

            // Add Administrator if not found
            if (adminId == 0)
            {
                var password = "EKsDY@4#UmM^scyZM5ys$$f2748XrkV^GXrpHekGa!a&*$eLQB$HiJQG!U4*&EYiwDNZ*aE87dg6PbU8WF3XNReik9!SZW*dDFDGP8Zavz%FhQeNzGYgrR5T@6FGbwJp";

                var customPasswordHasher = new Hash();
                var passwordHash = customPasswordHasher.HashPassword(password);

                var adminUser = new AppUser()
                {
                    LoginName = adminLoginName,
                    LoginNameUppercase = adminLoginName.ToUpper(),
                    PasswordHash = passwordHash,
                    IsAdmin = true,
                    Email= adminMail
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
