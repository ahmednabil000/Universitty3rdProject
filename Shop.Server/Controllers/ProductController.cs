<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Authorization;
=======
﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
>>>>>>> c34c059219630d2be7773638eea5b6538bf6bea8
using Microsoft.AspNetCore.Mvc;
using Shop.Server.Models;
using Shop.Server.Models.DTO;
using Shop.Server.ServicesContracts;

namespace Shop.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		public ProductController(IProductService productService)
		{
			_productService = productService;
		}
		[Authorize(Roles = "Admin")]
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
		public async Task<RestDTO<Product>> Post([FromQuery] Product product)
		{
			if (product == null) return new RestDTO<Product>()
			{
				Data = product,
			};
			await _productService.AddProductAsync(product);
			return new RestDTO<Product>()
			{
				Data = product,
			};
		}
		[HttpPut]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = $"{ApplicationRoles.Admin},{ApplicationRoles.SuperAdmin}")]
		public async Task<RestDTO<Product>> Put([FromQuery] Product product)
		{
			if (product != null)
			{
				await _productService.UpdateProductAsync(product);
			}
			return new RestDTO<Product>()
			{
				Data = product,

			};
		}
		[HttpDelete]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = $"{ApplicationRoles.Admin},{ApplicationRoles.SuperAdmin}")]
		public async Task<RestDTO<Product>> Delete([FromQuery] string productId)
		{
			var prod = await _productService.GetProductAsync(productId);
			await _productService.DeleteProductAsync(productId);
			return new RestDTO<Product>() { Data = prod };
		}

	}
}
