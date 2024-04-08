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
	}
}
