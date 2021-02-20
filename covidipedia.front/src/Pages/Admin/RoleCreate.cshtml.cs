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
    public class RoleCreateModel : PageModel
    {
        private RoleManager<IdentityRole> roleManager;
        public RoleCreateModel(RoleManager<IdentityRole> roleMgr)
        {
            roleManager = roleMgr;
        }



        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Required]
            [Display(Name = "Nom du Rôle")]
            public string RoleName { get; set; }


        }




        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Test for an existing user with the same LoginName



            var role = new IdentityRole
            {
                Name = Input.RoleName,

            };
            {
                if (ModelState.IsValid)
                {
                    IdentityResult result = await roleManager.CreateAsync(role);
                    if (result.Succeeded)
                        return RedirectToPage("Role");

                }
                return Page();
            }
        }
    }
}
