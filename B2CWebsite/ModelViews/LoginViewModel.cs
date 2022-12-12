
using System;
using System.ComponentModel.DataAnnotations;
 

namespace B2CWebsite.ModelViews
{
    public class LoginViewModel
    {
        [Key]
        [MaxLength(100)]
        [Required(ErrorMessage = ("Please enter your email"))]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Not Email Format")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter your password")]
        [MinLength(3, ErrorMessage = "You must enter at least 3 characters")]
        public string Password { get; set; }
    }
}
