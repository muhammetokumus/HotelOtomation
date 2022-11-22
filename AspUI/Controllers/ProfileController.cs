using AspUI.Models;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspUI.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public ProfileController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.Name = values.Name;
            model.Surname = values.Surname;
            model.Email = values.Email;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserUpdateViewModel user)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.Name = user.Name;
            values.Surname = user.Surname;
            values.Email = user.Email;
            var result = await _userManager.UpdateAsync(values);
            return RedirectToAction("Index", "Profile");
        }

        public IActionResult Password()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Password(UserUpdateViewModel user)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, user.Password);
            var result = await _userManager.UpdateAsync(values);
            await _signInManager.SignOutAsync();
            return RedirectToAction("LogIn", "Account");
        }
    }
}
