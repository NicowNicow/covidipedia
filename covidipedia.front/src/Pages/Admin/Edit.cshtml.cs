using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class EditModel : PageModel
    {
        private UserManager<ApplicationUser> userManager;
        public EditModel(UserManager<ApplicationUser> usrMgr)
        {
            userManager = usrMgr;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Key]
            public string Id { get; set; }

            [Required]
            [StringLength(32, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [Display(Name = "Login Name")]
            public string LoginName { get; set; }
            
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
            [Display(Name = "Admin")]
            public bool IsAdmin { get; set; }

            [Display(Name = "Medical")]
            public bool IsMedical { get; set; }

        }
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

            Input = new InputModel
            {
                Id = user.Id,
                LoginName = user.UserName,
                Email= user.Email,
                IsAdmin= await userManager.IsInRoleAsync(user, "Admin"),
                IsMedical= await userManager.IsInRoleAsync(user, "Medical")
                
            };

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await userManager.FindByIdAsync(Input.Id);

            if (user == null)
            {
                return NotFound();
            }

           

            user.UserName = Input.LoginName;
            user.Email = Input.Email;
            if(Input.IsAdmin)
            {
                await userManager.AddToRoleAsync(user, "Admin");
            } else
            {
                await userManager.RemoveFromRoleAsync(user, "Admin");
            }
            
            if(Input.IsMedical)
            {
                await userManager.AddToRoleAsync(user, "Medical");
            } else
            {
                await userManager.RemoveFromRoleAsync(user, "Medical");
            }

            if (!string.IsNullOrEmpty(Input.Email) && !string.IsNullOrEmpty(Input.LoginName))
            {
                IdentityResult result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                    return RedirectToPage("./Index");
            }


            return Page();
            }
        }
}
