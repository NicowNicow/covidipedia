using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using covidipedia.front.Data;
using covidipedia.front.src.Entities;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace covidipedia.front.src.Pages.Admin.Users
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public CreateModel(ApplicationDbContext context)
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
            [StringLength(32, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
            public string Password { get; set; }

            [Display(Name = "Admin")]
            public bool IsAdmin { get; set; }
            [Display(Name = "Must Change Password")]
            public bool MustChangePassword { get; set; }
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
                .Where(u => u.LoginNameUppercase == Input.LoginName.ToUpper())
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
                    IsAdmin= Input.IsAdmin,
                    MustChangePassword= Input.MustChangePassword
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
                ModelState.AddModelError(string.Empty, "Login Name already exisits.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
