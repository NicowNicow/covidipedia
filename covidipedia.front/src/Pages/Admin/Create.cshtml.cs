using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using covidipedia.front.Areas.Identity.Data;
using covidipedia.front.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace covidipedia.front.Pages {
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel {

            private UserManager<ApplicationUser> userManager;

            public CreateModel(UserManager<ApplicationUser> usrMgr)
            {
                userManager = usrMgr;
            }

            

            [BindProperty]
            public InputModel Input { get; set; }
            public class InputModel
            {
                

                [Required]
                [Display(Name = "Email")]
                public string Email { get; set; }
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }


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
                UserName = Input.Email,
                Email = Input.Email,
                EmailConfirmed = true
            };

            IdentityResult result = await userManager.CreateAsync(newUser, Input.Password);
            if (result.Succeeded)
                return RedirectToPage("./Index");
            else
            {
                foreach (IdentityError error in result.Errors)
                    ModelState.AddModelError("", error.Description);
                return RedirectToPage("./Index");
            }

            }
        }
    }

