using System.ComponentModel.DataAnnotations;

namespace MyVidly.Models
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }    

        [Display(Name = "Remeber Me")]

        public bool RememberMe { get; set;}
    }
}
