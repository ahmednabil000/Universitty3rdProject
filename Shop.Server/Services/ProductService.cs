using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shop.Server.Models;
using Shop.Server.Models.DTO;
using Shop.Server.ServicesContracts;

namespace Shop.Server.Services
{
	public class ProductService : IProductService
	{
		private readonly DbAa7408UniversityprojectContext _context;
		public ProductService(DbAa7408UniversityprojectContext context)
		{
			_context = context;
		}
		public async Task<Product> GetProductAsync(Guid productId)
		{
			var prod = await _context.Products.FindAsync(productId);
			return prod;
		}

		public async Task AddProductAsync(Product product)
		{
			await _context.Products.AddAsync(product);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteProductAsync(Guid prodId)
		{
			var prod = await _context.Products.FirstOrDefaultAsync(p => p.PId == prodId);
			if (prod != null) _context.Products.Remove(prod);
			await _context.SaveChangesAsync();
		}

		public async Task<List<Product>> GetProductsAsync(RequestDTO input)
		{
			input = input == null ? new RequestDTO() : input;
			var productsQuery = _context.Products.AsQueryable();

			if (!input.FilterQuery.IsNullOrEmpty())
			{
				productsQuery.Where(p => p.PName.Contains(input.FilterQuery));
			}
			productsQuery.Skip(input.PageSize * input.PageIndex).Take(input.PageSize);

			return await productsQuery.ToListAsync();
		}

		public async Task UpdateProductAsync(Product product)
		{
			_context.Update(product);
			await _context.SaveChangesAsync();
		}

	}
}
