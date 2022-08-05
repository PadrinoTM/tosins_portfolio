using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyProfile.ViewModel;
using MyVidly.Models.Context;
using System.Linq;

namespace MyVidly.Controllers
{
    public class AdminController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly MyVidlyDbContext _context;

        public AdminController(SignInManager<IdentityUser> signInManager, MyVidlyDbContext context)
        {
            this.signInManager = signInManager;
            _context = context;
        }

        [Authorize]
        public IActionResult Dashboard()
        {
            DashboardViewModel dashboard = new DashboardViewModel()
            {

                Experiences = _context.Experiencez.ToList(),
                Skill = _context.Skillz.ToList(),
                Projects = _context.Projectz.ToList()
            };


            return View(dashboard);
        }
    }
}
