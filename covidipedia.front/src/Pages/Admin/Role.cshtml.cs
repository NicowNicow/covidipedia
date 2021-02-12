using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace covidipedia.front.src.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class RoleModel : PageModel
    {
        private RoleManager<IdentityRole> roleManager;
        public RoleModel(RoleManager<IdentityRole> roleMgr)
        {
            roleManager = roleMgr;
        }
      
        public async Task<IActionResult> OnPostCreate([Required] string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                    return RedirectToAction("Index");
                
            }
            return Page();
        }
    }
}
