using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace B2CWebsite.ModelViews
{
    public class RegisterViewModel
    {
        [Key]
        public int CustomerId { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Please enter your full name")]
        public string FullName { get; set; }
        [MaxLength(150)]
        [Required(ErrorMessage = "Please enter your Email")]
        [DataType(DataType.EmailAddress)]
        [Remote(action: "ValidateEmail", controller: "Account")]
        public string Email { get; set; }

        [MaxLength(11)]
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Remote(action: "ValidatePhone", controller: "Account")]
        public string Phone { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter your password")]
        [MinLength(3, ErrorMessage = "Your password must have at least 3 characters")]
        public string Password { get; set; }

        [MinLength(3, ErrorMessage = "Your password must have at least 3 characters")]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "wrong password")]
        public string ConfirmPassword { get; set; }
    }
}
