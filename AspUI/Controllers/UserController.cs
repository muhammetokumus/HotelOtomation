using AspUI.Models;
using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AspUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        public UserController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var admin = await _userManager.GetUsersInRoleAsync("Admin");
            var users = new List<AppUser>();
            foreach (var user in admin)
            {
                users = _userManager.Users.Where(i => i.Id != user.Id).ToList();
            }
            return View(users);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == id);
            var result = await _userManager.DeleteAsync(user);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RoleAssign(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var roles = _roleManager.Roles.Where(i => i.Name != "Admin").ToList();
            var userRoles = await _userManager.GetRolesAsync(user);
            var roleAssigns = new List<RoleAssignViewModel>();
            ViewBag.Username = user.UserName;
            roles.ForEach(role =>
                roleAssigns.Add(new RoleAssignViewModel
                {
                    Id = role.Id,
                    Name = role.Name,
                    HasAssign = userRoles.Contains(role.Name)
                }));
            return View(roleAssigns);
        }

        [HttpPost]
        public async Task<IActionResult> RoleAssign(List<RoleAssignViewModel> models, int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            foreach (var role in models)
            {
                if (role.HasAssign)
                {
                    await _userManager.AddToRoleAsync(user, role.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, role.Name);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
