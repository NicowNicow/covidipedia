using covidipedia.front.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace covidipedia.front.Services
{
    public static class CookieValidator
    {
        public static async Task ValidateAsync(CookieValidatePrincipalContext context)
        {
            if (!await ValidateCookieAsync(context))
            {
                context.RejectPrincipal();
                await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
        }

        private static async Task<bool> ValidateCookieAsync(CookieValidatePrincipalContext context)
        {
            var claimsPrincipal = context.Principal;

            var uid = (from c in claimsPrincipal.Claims
                       where c.Type == ClaimTypes.NameIdentifier
                       select c.Value).FirstOrDefault();

            if (!int.TryParse(uid, out int userId))
            {
                return false;
            }

            var rowVersionString = (from c in claimsPrincipal.Claims
                                    where c.Type == ClaimTypes.UserData
                                    select c.Value).FirstOrDefault();

            if (string.IsNullOrEmpty(rowVersionString))
            {
                return false;
            }

            byte[] rowVersion = Encoding.Unicode.GetBytes(rowVersionString);

            var applicationDbContext = context.HttpContext.RequestServices.GetRequiredService<ApplicationDbContext>();

            return await applicationDbContext.AppUsers
                .AsNoTracking()
                .Where(a => a.Id == userId)
                .Select(a => a.RowVersion.SequenceEqual(rowVersion))
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }
    }
}
