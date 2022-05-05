using ECom.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EComWeb.Controllers;

public class UserRoles : Controller
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;

    public UserRoles(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager,
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
        var user = await _userManager.FindByIdAsync(userId.ToString());
        foreach (var role in _roleManager.Roles.ToList())
        {
            
        }
        return View();
    }
}