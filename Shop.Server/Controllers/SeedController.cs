
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class SeedController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    public SeedController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    [HttpPost]
    [Route("AddSuperAdminUser")]
    public async Task<IActionResult> AddSuperAdminUser()
    {
        try
        {

            var u = await _userManager.FindByEmailAsync("superadmin@gmail.com");
            if (u != null) return Ok();

            string password = "Ahmed3400";
            var user = new IdentityUser
            {
                UserName = "SuperAdmin",
                Email = "superadmin@gmail.com",
            };
            var resault = await _userManager.CreateAsync(user, password);
            var res2 = await _userManager.AddToRoleAsync(user, ApplicationRoles.SuperAdmin);
            if (resault.Succeeded && res2.Succeeded)
                return Ok();

            return BadRequest(resault.Errors);
        }
        catch (Exception ex)
        {
            var problem = new ProblemDetails();
            problem.Detail = ex.Message;
            return StatusCode(StatusCodes.Status500InternalServerError, problem);
        }

    }
    [HttpPost]
    [Route("AddApplicationRoles")]
    public async Task<IActionResult> AddApplicationRules()
    {
        await _roleManager.CreateAsync(new IdentityRole(ApplicationRoles.SuperAdmin));
        await _roleManager.CreateAsync(new IdentityRole(ApplicationRoles.Admin));
        await _roleManager.CreateAsync(new IdentityRole(ApplicationRoles.DeliveryMan));
        return Ok();
    }
}
