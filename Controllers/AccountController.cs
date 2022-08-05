using Microsoft.AspNetCore.Mvc;
using MyVidly.Models;
using System.Threading.Tasks;
//using IdentityManager.Models;

using Microsoft.AspNetCore.Identity;
/*using Microsoft.AspNet.Identity;*/

namespace MyVidly.Controllers
{
    
    public class AccountController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager; 
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Register(string returnurl=null)
        {
            ViewData["ReturnUrl"] = returnurl;
            RegisterModel registerViewModel = new RegisterModel();
            return View(registerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model, string returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            returnurl = returnurl ?? Url.Content("~/");
            if (!ModelState.IsValid)
            {
                var user = new AppUser { UserName = model.Email, Email = model.Email, Name = model.Name, };
                var result = await _userManager.CreateAsync(user, model.Password); 
                if (result.Succeeded)
                {
                  await _signInManager.SignInAsync(user, isPersistent: true);
                    return LocalRedirect(returnurl);
                }
                AddErrors(result);
            }
            RegisterModel registerViewModel = new RegisterModel();
            return View(registerViewModel);

        }

        [HttpGet]
        public IActionResult Login(string returnurl=null)
        {
           ViewData["ReturnUrl"] = returnurl;
         /*  LoginModel loginViewModel = new LoginModel();*/
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model, string returnurl=null)
        {

           ViewData["ReturnUrl"] = returnurl;
            returnurl = returnurl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                { 
                    return LocalRedirect(returnurl);
                }
                if (result.IsLockedOut)
                {
                    return View("LockedOut"); 
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt.");
                    return View(model);
                }
               
            }
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(RegisterModel model)
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
         
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
         
            return View();
        }

        [HttpGet]
        public IActionResult ForgotPasswordConfirmation()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        {

         
            return View(model);

        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
           
        }


    }
    
}
