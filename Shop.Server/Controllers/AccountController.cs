using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Shop.Server.Models.DTO;
using Shop.Server.Services;
using Shop.Server.ServicesContracts;
using System.Data;

namespace Shop.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly IAccountService _accountService;

		public AccountController(IConfiguration configuration, IAccountService accountService)
		{
			configuration = _configuration;
			_accountService = accountService;
		}
		[HttpPost]
		[Route("register")]


		public async Task<IActionResult> register([FromQuery]Registration registration)
		{
			var result = await _accountService.RegisterAsync(registration);
			if (result.Succeeded)
			{
				return Ok("You have regiseterd correctly");
			}
			else
			{
				return BadRequest(result.Errors);
			}
		}
		[HttpPost]
		[Route("login")]

		public string login(LogIn login)
		{
			SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection").ToString());
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM LogIn WHERE Email = '" + login.Email + "' AND Password = '" + login.Password + "'", sqlConnection);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			if (dataTable.Rows.Count == 0)
			{
				return "Failed";
			}
			else
			{
				return "Success";
			}
		}

	}
}
