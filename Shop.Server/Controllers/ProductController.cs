
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Shop.Server.Models;
using Shop.Server.Models.DTO;
using Shop.Server.ServicesContracts;
using Microsoft.AspNetCore.Cors;

namespace Shop.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[EnableCors]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public async Task<RestDTO<List<Product>>> Get([FromQuery] RequestDTO input)
		{
			var products = await _productService.GetProductsAsync(input);

			return new RestDTO<List<Product>>
			{
				Data = products,
				PageIndex = input.PageIndex,
				PageSize = input.PageSize
			};
		}
		[HttpPost]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = $"{ApplicationRoles.Admin},{ApplicationRoles.SuperAdmin}")]
		public async Task<IActionResult> Post([FromQuery] Product product)
		{
			try
			{
				var res = await _productService.AddProductAsync(product);
				if (!res.IsSucceed) return BadRequest(res);

				return Ok(res);
			}
			catch (Exception ex)
			{
				var problem = new ProblemDetails();
				problem.Detail = ex.Message;
				return StatusCode(StatusCodes.Status500InternalServerError, problem);
			}


		}
		[HttpPut]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = $"{ApplicationRoles.Admin},{ApplicationRoles.SuperAdmin}")]
		public async Task<IActionResult> Put([FromQuery] Product product)
		{
			try
			{
				var res = await _productService.UpdateProductAsync(product);
				if (!res.IsSucceed) return BadRequest(res);

				return Ok(res);
			}
			catch (Exception ex)
			{
				var problem = new ProblemDetails();
				problem.Detail = ex.Message;
				return StatusCode(StatusCodes.Status500InternalServerError, problem);
			}
		}
		[HttpDelete]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = $"{ApplicationRoles.Admin},{ApplicationRoles.SuperAdmin}")]
		public async Task<IActionResult> Delete([FromQuery] string productId)
		{
			try
			{
				var res = await _productService.DeleteProductAsync(productId);
				if (!res.IsSucceed) return BadRequest(res);

				return Ok(res);
			}
			catch (Exception ex)
			{
				var problem = new ProblemDetails();
				problem.Detail = ex.Message;
				return StatusCode(StatusCodes.Status500InternalServerError, problem);
			}
		}

	}
}
