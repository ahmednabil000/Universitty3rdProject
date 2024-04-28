
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Shop.Server.Models.DTO;
using Shop.Server.ServicesContracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shop.Server.Services
{
	public class AccountService:IAccountService
	{
		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly IConfiguration _configuration;

		public AccountService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager,IConfiguration configuration)
		{ 
			_signInManager = signInManager;
			_userManager = userManager;
			_configuration = configuration;
		}
	
		public async Task<string> LoginAsync(LogIn login)
		{
			var token =await GenerateTokenAsync(login);

			return token;

		}

		public async Task<IdentityResult> RegisterAsync(Registration registration)
		{

			var user = new IdentityUser { UserName = registration.Email, Email = registration.Email };
			var result = await _userManager.CreateAsync(user, registration.Password);

			return result;
		}

		private async Task<string> GenerateTokenAsync(LogIn login)
		{
			var user = await _userManager.FindByEmailAsync(login.Email);
			if(user == null) throw new Exception("User not found");

			var key = _configuration["JWT:Key"];	
			var issuer= _configuration["JWT:Issuer"];	

			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
			var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var roles =await _userManager.GetRolesAsync(user);
			var claims = new List<Claim>
			{
				new Claim("user-id",user.Id)
			};
			foreach(var role in roles)
			{
				claims.Add(new Claim(ClaimTypes.Role, role));
			}

			var token = new JwtSecurityToken(
				issuer,
				null,
				claims, 
				expires: DateTime.Now.AddHours(1),
				signingCredentials: signingCredentials);

			return new JwtSecurityTokenHandler().WriteToken(token);


		}

	
	}
}
