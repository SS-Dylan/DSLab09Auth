using DSLab09Auth.Models.ViewModels;
using DSLab09Auth.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DSLab09Auth.Controllers;

[Authorize(Roles = "Admin")]
public class UserController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUserRepository _userRepo;
    private readonly IRoleRepository _roleRepo;

    public UserController(IRoleRepository roleRepo, IUserRepository userRepo,
        ILogger<HomeController> logger)
    {
        _logger = logger;
        _userRepo = userRepo;
        _roleRepo = roleRepo;
    }

    public async Task<IActionResult> Index()
    {
        var users = await _userRepo.ReadAllAsync();
        var userList = users
        .Select(u => new UserListVM
        {
            Email = u.Email,
            Username = u.UserName,
            NumberOfRoles = u.Roles.Count,
            RoleNames = string.Join(",", u.Roles.ToArray())
        });
        return View(userList);
    }

    public async Task<IActionResult> AssignRole([Bind(Prefix ="Id")]string username)
    {
        var user = await _userRepo.ReadByUsernameAsync(username);
        if (user == null)
        {
            return RedirectToAction("Index");
        }
        var allRoles = _roleRepo.ReadAll().ToList();
        var allRoleNames = allRoles.Select(r => r.Name);
        var rolesUserDoNotHave = allRoleNames.Except(user.Roles);
        ViewData["User"] = user;
        return View(rolesUserDoNotHave);
    }

    [HttpPost]
    public async Task<IActionResult> AssignTheRole(string roleName, string username)
    {
        await _userRepo.AssignRoleAsync(username, roleName);
        return RedirectToAction("Index");
    }
}
