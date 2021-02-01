using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace covidipedia.front.src.Entities
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Login Name")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string LoginName { get; set; }

        [Required]
        [StringLength(32)]
        public string LoginNameUppercase { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
        public string Password { get; set; }
    }
}
