using System.ComponentModel.DataAnnotations;

namespace MyVidly.Models
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }   
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]   
        [Display(Name = "Password")]    
        public string Password { get; set; } 
        
        [DataType(DataType.Password)]   
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation passwords do not match")]
        public bool ConfirmPassword { get; set; }

        [Required]
        public string Name { get; set; }    

    }
}
 