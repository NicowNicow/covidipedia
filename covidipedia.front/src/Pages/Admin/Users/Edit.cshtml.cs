using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using covidipedia.front.Data;
using covidipedia.front.src.Entities;
using System.ComponentModel.DataAnnotations;

namespace covidipedia.front.src.Pages.Admin.Users
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Key]
            public int Id { get; set; }

            [Required]
            [StringLength(32, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [Display(Name = "Login Name")]
            public string LoginName { get; set; }

            [StringLength(32, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
            public string Password { get; set; }
            [Display(Name = "Admin")]
            public bool IsAdmin { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.AppUsers
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            Input = new InputModel
            {
                Id = user.Id,
                LoginName = user.LoginName,
                IsAdmin = user.IsAdmin
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _context.AppUsers.FirstOrDefaultAsync(m => m.Id == Input.Id);

            if (user == null)
            {
                return NotFound();
            }

            if (user.LoginNameUppercase != Input.LoginName.ToUpper())
            {
                // Test for an existing user with the new LoginName
                int testId = await _context.AppUsers
                    .Where(u => u.LoginNameUppercase == Input.LoginName.ToUpper())
                    .Select(u => u.Id)
                    .FirstOrDefaultAsync();

                if (testId != 0)
                {
                    ModelState.AddModelError(string.Empty, "Login Name already exisits.");
                    return Page();
                }
            }

            // Hash new password if provided
            if (!string.IsNullOrEmpty(Input.Password))
            {
                var passwordHasher = new Hash();
                var hashedPassword = passwordHasher.HashPassword(Input.Password);
                user.PasswordHash = hashedPassword;
            }

            user.LoginName = Input.LoginName;
            user.LoginNameUppercase = Input.LoginName.ToUpper();
            user.IsAdmin = Input.IsAdmin;

            _context.Attach(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppUserExists(user.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AppUserExists(int id)
        {
            return _context.AppUsers.Any(e => e.Id == id);
        }
    }
}
