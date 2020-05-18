using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRHub_UI.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        [Display(Name ="Email Address")]
        public string EmailAddress { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "limited to 50", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Confirm password")]
        [Compare("Password",ErrorMessage = "The  password and confirmation do not match")]
        public string ConfirmPassword { get; set; }
    }

}
