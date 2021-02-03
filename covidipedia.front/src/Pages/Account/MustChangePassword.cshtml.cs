using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using covidipedia.front.Data;
using covidipedia.front.src.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace covidipedia.front.src.Pages.Account
{
    [Authorize]
    public class MustChangePasswordModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public MustChangePasswordModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public string ReturnUrl { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Key]
            public int Id { get; set; }

            [Required]
            [StringLength(32, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "New password")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm new password")]
            [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }

            public byte[] RowVersion { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage(Url.Content("~/"));
            }

            returnUrl ??= Url.Content("~/");
            ReturnUrl = returnUrl;

            int currentUserId;
            var idClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (idClaim == null)
            {
                // Logout user and clear the existing external cookie
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToPage(Url.Content("~/"));
            }

            try
            {
                currentUserId = Int32.Parse(idClaim.Value);
            }
            catch (FormatException)
            {
                // Logout user and clear the existing external cookie
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToPage(Url.Content("~/"));
            }

            var user = await _context.AppUsers
                .AsNoTracking()
                .Where(a => a.Id == currentUserId)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            if (user == null)
            {
                // Logout user and clear the existing external cookie
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToPage(Url.Content("~/"));
            }

            Input = new InputModel()
            {
                Id = user.Id,
                RowVersion = user.RowVersion
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage(Url.Content("~/"));
            }

            var user = await _context.AppUsers
                .AsNoTracking()
                .Where(a => a.Id == Input.Id)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            if (user == null)
            {
                // Logout user and clear the existing external cookie
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToPage(Url.Content("~/"));
            }

            // Test for concurrency conflict
            if (!user.RowVersion.SequenceEqual(Input.RowVersion))
            {
                ModelState.Clear(); // required to update Input model

                ModelState.AddModelError(string.Empty, "There was an issue updating " +
                        "the record. Please try again.");

                Input = new InputModel()
                {
                    Id = user.Id,
                    RowVersion = user.RowVersion
                };

                return Page();
            }

            // Verify the new password does not equal the current password.
            var passwordHasher = new Hash();
            if (passwordHasher.VerifyPassword(user.PasswordHash, Input.NewPassword))
            {
                ModelState.AddModelError(string.Empty, "You must use a new password.");
                return Page();
            }

            var hashedPassword = passwordHasher.HashPassword(Input.NewPassword);
            user.PasswordHash = hashedPassword;
            user.MustChangePassword = false;

            _context.Attach(user).State = EntityState.Modified;

            try
            {
                _context.Entry(user).OriginalValues["RowVersion"] = Input.RowVersion;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var entry = ex.Entries.Single();
                var clientValues = (AppUser)entry.Entity;
                var databaseEntry = entry.GetDatabaseValues();
                if (databaseEntry == null)
                {
                    // Logout user and clear the existing external cookie
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    return RedirectToPage(Url.Content("~/"));
                }
                else
                {
                    ModelState.Clear(); // required to update Input model

                    ModelState.AddModelError(string.Empty, "There was an issue updating " +
                        "the record. Please try again.");

                    var databaseValues = (AppUser)databaseEntry.ToObject();
                    Input = new InputModel()
                    {
                        Id = databaseValues.Id,
                        RowVersion = databaseValues.RowVersion
                    };
                }

                return Page();
            }
            catch (RetryLimitExceededException /* dex */)
            {
                // Retry Limit = 6
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, " +
                    "see your system administrator.");
            }
            catch (DbUpdateException)
            {
                throw new InvalidOperationException("DbUpdateException occurred updating a user.");
            }

            // Logout user and clear the existing external cookie
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            string rowVersionString = Encoding.Unicode.GetString(user.RowVersion);
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.Integer),
            new Claim(ClaimTypes.Name, user.LoginName),
            new Claim(ClaimTypes.UserData, rowVersionString)
        };

            if (user.IsAdmin)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }

            if (user.MustChangePassword)
            {
                claims.Add(new Claim(AppUser.MustChangePasswordClaimType, string.Empty));
            }

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                new AuthenticationProperties
                {
                    IsPersistent = Input.RememberMe
                });

            returnUrl ??= Url.Content("~/");

            return LocalRedirect(returnUrl);
        }

    }
}
