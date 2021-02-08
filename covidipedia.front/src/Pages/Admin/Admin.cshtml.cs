using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using covidipedia.front.Areas.Identity.Data;
using covidipedia.front.Data;
using System.ComponentModel.DataAnnotations;

namespace covidipedia.front.Pages {
    public class AdminModel : PageModel {

            private UserManager<ApplicationUser> userManager;

            public AdminModel(UserManager<ApplicationUser> usrMgr)
            {
                userManager = usrMgr;
            }

            

            [BindProperty]
            public InputModel Input { get; set; }
            public class InputModel
            {
                [Required]
                [Display(Name = "Login Name")]
                public string LoginName { get; set; }

                [Required]
                [Display(Name = "Email")]
                public string Email { get; set; }

                
            }


            public async Task<IActionResult> OnPostAsync()
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

            // Test for an existing user with the same LoginName



            var newUser = new ApplicationUser
            {
                UserName = Input.LoginName,
                Email = Input.Email
            };

            IdentityResult result = await userManager.CreateAsync(newUser);
            if (result.Succeeded)
                return RedirectToPage("Index");
            else
            {
                foreach (IdentityError error in result.Errors)
                    ModelState.AddModelError("", error.Description);
                return RedirectToPage("./Index");
            }

            }
        }
    }

