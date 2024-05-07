using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
		private readonly IHttpContextAccessor _contextAccessor;

		public AccountController(IConfiguration configuration, IAccountService accountService, IHttpContextAccessor httpContextAccessor)
		{
			_configuration = configuration;
			_accountService = accountService;
			_contextAccessor = httpContextAccessor;
		}
		[HttpPost]
		[Route("register")]


		public async Task<IActionResult> register([FromQuery] RegistrationDTO registration)
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

		public async Task<IActionResult> login([FromQuery] LogInDTO login)
		{
			try
			{
				var result = await _accountService.CheckLoginCredentialsAsync(login);
				var token = await _accountService.GenerateTokenAsync(login);
				_contextAccessor.HttpContext!.Response.Headers["Authorization"] = token;
				return Ok(token);
			}
			catch (Exception ex)
			{
				var problem = new ProblemDetails();
				problem.Detail = ex.Message;
				problem.Status = StatusCodes.Status404NotFound;

				return BadRequest(problem);
			}

		}
		[HttpPut]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = $"{ApplicationRoles.Admin},{ApplicationRoles.SuperAdmin}")]
		[Route("AddDeliveryManUser")]

		public async Task<IActionResult> AddDeliveryManUser(string email)
		{
			try
			{
				var resault = await _accountService.AddDeliveryManUserAsync(email);
				if (resault.IsSucceed)
				{
					return Ok(resault.Message);
				}
				else
				{
					return BadRequest(resault.Message);
				}
			}
			catch (Exception ex)
			{
				var problem = new ProblemDetails();
				problem.Detail = ex.Message;
				problem.Status = StatusCodes.Status500InternalServerError;
				return StatusCode(StatusCodes.Status500InternalServerError, problem);
			}
		}
		[HttpPut]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = $"{ApplicationRoles.Admin},{ApplicationRoles.SuperAdmin}")]
		[Route("AddAdminUSer")]

		public async Task<IActionResult> AddAdminUser(string email)
		{
			try
			{
				var resault = await _accountService.AddAdminUserAsync(email);
				if (resault.IsSucceed)
				{
					return Ok(resault.Message);
				}
				else
				{
					return BadRequest(resault.Message);
				}
			}
			catch (Exception ex)
			{
				var problem = new ProblemDetails();
				problem.Detail = ex.Message;
				problem.Status = StatusCodes.Status500InternalServerError;
				return StatusCode(StatusCodes.Status500InternalServerError, problem);
			}
		}
		[HttpPut]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[Route("ChangePassword")]
		public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO changePassword)
		{
			try
			{
				var resault = await _accountService.ChangePasswordAsync(changePassword);
				if (resault.IsSucceed)
				{
					return Ok("Password changed successfully");
				}
				else
				{
					return BadRequest(resault.Message);
				}
			}
			catch (Exception ex)
			{
				var problem = new ProblemDetails();
				problem.Detail = ex.Message;
				problem.Status = StatusCodes.Status500InternalServerError;
				return StatusCode(StatusCodes.Status500InternalServerError, problem);
			}
		}
	}
}
