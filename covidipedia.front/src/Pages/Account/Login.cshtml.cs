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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace covidipedia.front.src.Pages.Account
{
    
 
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public LoginModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }
        
       

        public class InputModel
        {
            [Required]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [StringLength(32, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            // Clear the existing external cookie
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            returnUrl ??= Url.Content("~/");

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            

            if (ModelState.IsValid)
            {
                var user = await AuthenticateUser(Input.Email, Input.Password);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
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
                if (user.IsMedical)
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Medical"));
                }
                if (user.MustChangePassword)
                {
                    claims.Add(new Claim(AppUser.MustChangePasswordClaimType, string.Empty));
                }

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties
                    {
                        IsPersistent = Input.RememberMe
                    });

                if (!Url.IsLocalUrl(returnUrl))
                {
                    returnUrl = Url.Content("~/");
                }
                


                return LocalRedirect(returnUrl);

            }

            // Something failed. Redisplay the form.
            return Page();
        }

        private async Task<AppUser> AuthenticateUser(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                return null;

            var user = await _context.AppUsers
                .AsNoTracking()
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            if (user == null)
                return null;

            //if (password != user.Password)
            //    return null;

            //return user;

            var customPasswordHasher = new Hash();
            if (customPasswordHasher.VerifyPassword(user.PasswordHash, password))
            {
                return user;
            }
            else
            {
                // Login Failed
                return null;
            }
        }
    }
}
