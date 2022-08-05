using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MyVidly.Models
{
  
    public class AppUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }

    }
}
