using Microsoft.AspNetCore.Identity;
using Shop.Server.Models.DTO;

namespace Shop.Server.ServicesContracts
{
	public interface IAccountService
	{
		public Task<IdentityResult> RegisterAsync(RegistrationDTO registration);
		public Task<string> GenerateTokenAsync(LogInDTO login);
		public Task<bool> CheckLoginCredentialsAsync(LogInDTO login);
	}
}
