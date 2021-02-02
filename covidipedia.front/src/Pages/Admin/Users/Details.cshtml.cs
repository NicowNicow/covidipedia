using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using covidipedia.front.Data;
using covidipedia.front.src.Entities;

namespace covidipedia.front.src.Pages.Admin.Users
{
    public class DetailsModel : PageModel
    {
        private readonly covidipedia.front.Data.ApplicationDbContext _context;

        public DetailsModel(covidipedia.front.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
