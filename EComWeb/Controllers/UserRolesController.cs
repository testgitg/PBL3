using ECom.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EComWeb.Controllers;

[Authorize(Roles = "Admin")]
public class UserRolesController : Controller
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;

    public UserRolesController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }
    // GET
    public async Task<IActionResult> Index(int userId)
    {
        var viewModel = new UserRolesViewMode();
        viewModel.RoleNames = new List<string>();
        var user = await _userManager.FindByIdAsync(userId.ToString());
        viewModel.UserId = userId;
        viewModel.Username = user.UserName;
        var roleOfUser = await _userManager.GetRolesAsync(user);
        for (int i = 0; i < _roleManager.Roles.Count(); i++)
        {
            viewModel.RoleNames.Add(_roleManager.Roles.ToList()[i].Name);
            if (roleOfUser[0] == viewModel.RoleNames[i]) viewModel.SelectedRole = i;
        }
        return View(viewModel);
    }
    //POST
    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<IActionResult> Index(UserRolesViewMode viewMode)
    {
        if (!ModelState.IsValid) return BadRequest();
        var user = await _userManager.FindByIdAsync(viewMode.UserId.ToString());
        for (int i = 0; i < viewMode.RoleNames.Count; i++)
        {
            if (viewMode.SelectedRole == i) await _userManager.AddToRoleAsync(user, viewMode.RoleNames[i]);
            else await _userManager.RemoveFromRoleAsync(user, viewMode.RoleNames[i]);
        }
        return RedirectToAction("Index","User");
    }
}