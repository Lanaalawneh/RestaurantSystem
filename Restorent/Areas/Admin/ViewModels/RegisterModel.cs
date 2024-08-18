using System.ComponentModel.DataAnnotations;

namespace Restorent.Areas.Admin.ViewModels
{
    public class RegisterModel
    {
       
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Your Email")]
        public string? Email { get;  set; }


        //[Required(ErrorMessage = "Username is required")]
        //[StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters")]
        //[RegularExpression(@"^[a-zA-Z0-9_-]+$", ErrorMessage = "Username can only contain letters, numbers, underscores, and hyphens")]
        //public string? UserName { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password not Match")]
        public string? ConfirmPassword { get; set; }

        //[Display(Name = "I agree and accept the terms and conditions")]
        //public bool conditions { get; set; }

    }
}
