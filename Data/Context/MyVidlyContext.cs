using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MyVidly.Models;

namespace MyVidly.Models.Context
{
    public class MyVidlyDbContext : IdentityDbContext
    {
        public MyVidlyDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<AppUser> AppUser { get; set; }

        public DbSet<Skills> Skillz { get; set; }


        public DbSet<Project> Projectz { get; set; }


        public DbSet<Experience> Experiencez { get; set; }
    }
}


// public  DbSet<Customer> Customer { get; set; }
// public DbSet<ApplicationUser> ApplicationUser { get; set; }

//

/* protected override void OnModelCreating(ModelBuilder modelBuilder)
 {
     base.OnModelCreating(modelBuilder);
     modelBuilder.Entity<MembershipType>().HasData(
         new MembershipType() { Id = 1, Name = "rEAL", SignUpFee = 0, DurationInMonths = 0, DiscountRate = 0 },
         new MembershipType() { Id = 2, Name = "Fake", SignUpFee = 30, DurationInMonths = 1, DiscountRate = 10 },
         new MembershipType() { Id = 3, Name = "Easy", SignUpFee = 90, DurationInMonths = 3, DiscountRate = 15 });
 }
*/
