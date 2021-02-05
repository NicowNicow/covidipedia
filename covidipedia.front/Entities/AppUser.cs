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
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [MaxLength(84, ErrorMessage = "The {0} is max {1} characters long.")]
        public string PasswordHash { get; set; }

        [Display(Name = "Must Change Password")]
        public bool MustChangePassword { get; set; }

        [Display(Name = "Admin")]
        public bool IsAdmin { get; set; }

        [Display(Name = "Medical")]
        public bool IsMedical { get; set; }

        [Display(Name = "Code")]
        public int Code { get; set; }
        [Required]
        [MaxLength(11)]
        [MinLength(11)]
        [Display(Name = "RPPS")]
        public string RPPS { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public const string MustChangePasswordClaimType = "http://userswithoutidentity/claims/mustchangepassword";
    }

}

