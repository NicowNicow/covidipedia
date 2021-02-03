using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using covidipedia.front.Data;
using covidipedia.front.src.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace covidipedia.front.src.Pages.Admin.Users
{
    public class DeleteModel : PageModel
    {
        private readonly covidipedia.front.Data.ApplicationDbContext _context;

        public DeleteModel(covidipedia.front.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AppUser AppUser { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AppUser = await _context.AppUsers.FirstOrDefaultAsync(m => m.Id == id);

            if (AppUser == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.AppUsers
    .AsNoTracking()
    .FirstOrDefaultAsync(m => m.Id == AppUser.Id);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty,
                        "Unable to save changes. The User was deleted by another user. Click Cancel.");
                return Page();
            }

            _context.AppUsers.Remove(user);

            try
            {
                _context.Entry(user).OriginalValues["RowVersion"] = AppUser.RowVersion;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var entry = ex.Entries.Single();
                var databaseEntry = entry.GetDatabaseValues();
                if (databaseEntry == null)
                {
                    ModelState.AddModelError(string.Empty,
                        "Unable to save changes. The User was deleted by another user.");
                }
                else
                {
                    ModelState.Clear(); // required to update the model

                    ModelState.AddModelError(string.Empty, "The record you attempted to delete " +
                            "was modified by another user after you got the original values. The " +
                            "delete operation was canceled and the current values in the database " +
                            "have been displayed. You can continue to Delete again. " +
                            "Otherwise click Cancel.");

                    AppUser = (AppUser)databaseEntry.ToObject();
                }

                return Page();
            }
            catch (RetryLimitExceededException /* dex */)
            {
                // Retry Limit = 6
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            catch (DbUpdateException)
            {
                throw new InvalidOperationException("DbUpdateException occurred deleting a user.");
            }

            return RedirectToPage("./Index");
        }
    }
}
