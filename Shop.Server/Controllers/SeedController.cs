
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Server.Models;


[ApiController]
[Route("api/[controller]")]
[EnableCors]
public class SeedController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IHostEnvironment _hostEnvironment;
    private readonly DbAa7408UniversityprojectContext _context;
    public SeedController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, IHostEnvironment hostEnvironment, DbAa7408UniversityprojectContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _hostEnvironment = hostEnvironment;
        _context = context;
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
    [HttpPost]
    [Route("SeedProducts")]
    public async Task<IActionResult> SeedProducts()
    {

        using (var streamReader = new StreamReader($"Models/CSV/ProductsSheet.csv"))
        {
            using (var csvReader = new CsvReader(streamReader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                var idSet = new HashSet<string>();
                var productsDic = _context.Products.ToDictionary(p => p.Id);
                var records = csvReader.GetRecords<ProductCSV>().ToList();
                foreach (var item in records)
                {
                    if (idSet.Contains(item.Id)) continue;
                    if (productsDic.ContainsKey(item.Id)) continue;
                    var random = new Random();
                    int randomNumber = random.Next(1, 11);

                    var product = new Product
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Price = item.Price,
                        Quantity = item.Quantity,
                        CategoryId = randomNumber.ToString()
                    };
                    idSet.Add(item.Id);
                    await _context.Products.AddAsync(product);
                }
                await _context.SaveChangesAsync();
                return Ok();
            }
        }
    }
    [HttpPost]
    [Route("SeedCategories")]


    public async Task<IActionResult> SeedBakeryCategories()
    {
        var bakeryCategories = new List<Category>
        {
            new Category { Id = "1", Name = "Bread" },
            new Category { Id = "2", Name = "Pastries" },
            new Category { Id = "3", Name = "Cakes" },
            new Category { Id = "4", Name = "Cookies" },
            new Category { Id = "5", Name = "Muffins" },
            new Category { Id = "6", Name = "Donuts" },
            new Category { Id = "7", Name = "Pies" },
            new Category { Id = "8", Name = "Croissants" },
            new Category { Id = "9", Name = "Bagels" },
            new Category { Id = "10", Name = "Scones" }
        };
        await _context.Categories.AddRangeAsync(bakeryCategories);
        await _context.SaveChangesAsync();

        return Ok();
    }
}
