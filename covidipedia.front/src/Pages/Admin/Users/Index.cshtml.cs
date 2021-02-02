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
    public class IndexModel : PageModel
    {
        private readonly covidipedia.front.Data.ApplicationDbContext _context;

        public IndexModel(covidipedia.front.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<AppUser> AppUser { get;set; }

        public async Task OnGetAsync()
        {
            AppUser = await _context.AppUsers.ToListAsync();
        }
    }
}
