using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;


namespace covidipedia.front.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class AdminModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> RoleManager;

        public AdminModel(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> RoleManager)
        {
            this.userManager = userManager;
            this.RoleManager = RoleManager;
        }
    }
}
