using covidipedia.front.Areas.Identity.Data;
using covidipedia.front.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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

        private readonly IServiceProvider _serviceProvider;

        public EnsureAdministrator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            //initializing custom roles
            using var scope = _serviceProvider.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            IdentityResult roleResult;


            var roleExist = await roleManager.RoleExistsAsync("Admin");
            // ensure that the role does not exist
            if (!roleExist)
            {
                //create the roles and seed them to the database: 
                roleResult = await roleManager.CreateAsync(new IdentityRole("Admin"));
            }


            // find the user with the admin email 
            var _user = await userManager.FindByEmailAsync("covidipedia@gmail.com");

            // check if the user exists
            if (_user == null)
            {
                //Here you could create the super admin who will maintain the web app
                var poweruser = new ApplicationUser
                {
                    UserName = "covidipedia@gmail.com",
                    Email = "covidipedia@gmail.com",
                    EmailConfirmed= true,
                };
                string adminPassword = "E5Xko6%Xmd@e6";

                var createPowerUser = await userManager.CreateAsync(poweruser, adminPassword);
                if (createPowerUser.Succeeded)
                {
                    //here we tie the new user to the role
                    await userManager.AddToRoleAsync(poweruser, "Admin");

                }
            }
        }
        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    }
}