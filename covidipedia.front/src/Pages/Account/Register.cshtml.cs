using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using covidipedia.front.Data;
using covidipedia.front.src.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace covidipedia.front.src.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public RegisterModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {

            [Required]
            [StringLength(32, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [Display(Name = "Login Name")]
            public string LoginName { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(32, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
            public string Password { get; set; }

            [Required]
            [MaxLength(11)]
            [MinLength(11)]
            [Display(Name = "RPPS")]
            public string RPPS { get; set; }


        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Test for an existing user with the same LoginName
            int testId = await _context.AppUsers
                .Where(u => u.Email == Input.Email)
                .Select(u => u.Id)
                .FirstOrDefaultAsync();

            if (testId == 0)
            {
                var passwordHasher = new Hash();
                var hashedPassword = passwordHasher.HashPassword(Input.Password);
                var newUser = new AppUser
                {
                    LoginName = Input.LoginName,
                    LoginNameUppercase = Input.LoginName.ToUpper(),
                    PasswordHash = hashedPassword,
                    Email = Input.Email,
                    RPPS = Input.RPPS
                };

                _context.AppUsers.Add(newUser);
                try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    throw new InvalidOperationException("DbUpdateException occurred creating a new user.");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Email already exisits.");
                return Page();
            }

            return RedirectToPage("./Login");
        }
    }
}
