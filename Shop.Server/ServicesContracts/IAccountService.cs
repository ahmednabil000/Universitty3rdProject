using Microsoft.AspNetCore.Identity;
using Shop.Server.Models.DTO;

namespace Shop.Server.ServicesContracts
{
	public interface IAccountService
	{
		public Task<IdentityResult> RegisterAsync(Registration registration);
		public Task<string> LoginAsync(LogIn login);
	}
}
