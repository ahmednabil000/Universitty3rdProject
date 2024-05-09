
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Shop.Server.Models.DTO;
using Shop.Server.ServicesContracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shop.Server.Services
{
	public class AccountService : IAccountService
	{
		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly IConfiguration _configuration;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public AccountService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
		{
			_signInManager = signInManager;
			_userManager = userManager;
			_configuration = configuration;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<bool> CheckLoginCredentialsAsync(LogInDTO login)
		{
			var user = await _userManager.FindByEmailAsync(login.Email);
			if (user == null) throw new Exception("User not found");

			var result = await _userManager.CheckPasswordAsync(user, login.Password);

			if (result == false) throw new Exception("Password is not correct for the specified email");

			return true;
		}

		public async Task<IdentityResult> RegisterAsync(RegistrationDTO registration)
		{

			var user = new IdentityUser { UserName = registration.Email, Email = registration.Email };
			var result = await _userManager.CreateAsync(user, registration.Password);

			return result;
		}
		public async Task<string> GenerateTokenAsync(LogInDTO login)
		{
			var user = await _userManager.FindByEmailAsync(login.Email);
			if (user == null) throw new Exception("User not found");

			var key = _configuration["JWT:Key"];
			var issuer = _configuration["JWT:Issuer"];

			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
			var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var roles = await _userManager.GetRolesAsync(user);
			var claims = new List<Claim>
			{
				new Claim("user-id",user.Id)
			};
			foreach (var role in roles)
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

		public async Task<Resault<IdentityUser>> ChangePasswordAsync(ChangePasswordDTO changePasswordDTO)
		{
			var userId = _httpContextAccessor?.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "user-id")?.Value;

			var user = await _userManager.FindByIdAsync(userId!);

			var resault = await _userManager.ChangePasswordAsync(user!, changePasswordDTO.OldPassword, changePasswordDTO.NewPassword);

			if (!resault.Succeeded)
			{
				StringBuilder sb = new StringBuilder();
				resault.Errors.ToList().ForEach(e =>
				{
					sb.AppendLine(e.Description);
				});
				return new Resault<IdentityUser>(false, sb.ToString(), null);
			}

			return new Resault<IdentityUser>(true, "You have changed your password successfully", user);

		}

		public async Task<Resault<IdentityUser>> AddDeliveryManUserAsync(string email)
		{
			var user = await _userManager.FindByEmailAsync(email);
			if (user == null) return new Resault<IdentityUser>(false, "User not found", null);

			var result = await _userManager.AddToRoleAsync(user, ApplicationRoles.DeliveryMan);
			if (!result.Succeeded)
			{
				StringBuilder sb = new StringBuilder();
				result.Errors.ToList().ForEach(e =>
				{
					sb.AppendLine(e.Description);
				});
				return new Resault<IdentityUser>(false, sb.ToString(), null);
			}
			return new Resault<IdentityUser>(true, $"Role {ApplicationRoles.DeliveryMan} has been added to user {email}", user);
		}

		public async Task<Resault<IdentityUser>> AddAdminUserAsync(string email)
		{
			var user = await _userManager.FindByEmailAsync(email);
			if (user == null) return new Resault<IdentityUser>(false, "User not found", null);

			var result = await _userManager.AddToRoleAsync(user, ApplicationRoles.Admin);
			if (!result.Succeeded)
			{
				StringBuilder sb = new StringBuilder();
				result.Errors.ToList().ForEach(e =>
				{
					sb.AppendLine(e.Description);
				});
				return new Resault<IdentityUser>(false, sb.ToString(), null);
			}
			return new Resault<IdentityUser>(true, $"Role {ApplicationRoles.Admin} has been added to user {email}", user);
		}
	}
}
