using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using covidipedia.front.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace covidipedia.front.src.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private UserManager<ApplicationUser> userManager;
        public DeleteModel(UserManager<ApplicationUser> usrMgr)
        {
            userManager = usrMgr;
        }
        public string LoginName { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            LoginName = user.UserName;


            return Page();
        }
        public async Task<IActionResult> OnPostAsync(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToPage("./Index");
                
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return Page();
        }
    }
}
