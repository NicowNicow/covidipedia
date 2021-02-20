using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace covidipedia.front.src.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class RoleDeleteModel : PageModel
    {
        private RoleManager<IdentityRole> roleManager;
        public RoleDeleteModel(RoleManager<IdentityRole> roleMgr)
        {
            roleManager = roleMgr;
        }
        public string RoleName { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                return NotFound();
            }
            RoleName = role.Name;


            return Page();
        }
        public async Task<IActionResult> OnPostAsync(string id)
        {
            IdentityRole user = await roleManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await roleManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToPage("./Index");

            }
            else
                ModelState.AddModelError("", "User Not Found");
            return Page();
        }
    }
}
