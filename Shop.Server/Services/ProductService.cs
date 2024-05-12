using Microsoft.AspNetCore.Mvc;
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
		public async Task<Product> GetProductAsync(string productId)
		{
			var prod = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
			return prod;
		}

		public async Task<Resault<Product>> AddProductAsync(Product product)
		{
			await _context.Products.AddAsync(product);
			await _context.SaveChangesAsync();
			return new Resault<Product>(true, $"The product has been added successfully", product);
		}

		public async Task<Resault<Product>> DeleteProductAsync(string prodId)
		{
			var prod = await _context.Products.FirstOrDefaultAsync(p => p.Id == prodId);
			if (prod == null) return new Resault<Product>(false, $"Product not found", null);
			if (prod != null) _context.Products.Remove(prod);
			await _context.SaveChangesAsync();
			return new Resault<Product>(true, $"The product with id {prodId} has been deleted successfully", prod);
		}

		public async Task<List<Product>> GetProductsAsync(RequestDTO input)
		{
			input = input == null ? new RequestDTO() : input;
			var productsQuery = _context.Products.AsQueryable();

			if (!input.FilterQuery.IsNullOrEmpty())
			{
				productsQuery = productsQuery.Where(p => p.Name.Contains(input.FilterQuery));
			}
			productsQuery = productsQuery.Skip(input.PageSize * input.PageIndex).Take(input.PageSize);

			return await productsQuery.ToListAsync();
		}

		public async Task<Resault<Product>> UpdateProductAsync(Product product)
		{
			var prod = await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
			if (prod == null) return new Resault<Product>(false, $"There is no product with this id {product.Id}", null);
			_context.Update(product);
			await _context.SaveChangesAsync();
			return new Resault<Product>(true, $"The product with id {product.Id} has been updated successfully", product);
		}

		public async Task<Resault<ProductSale>> AddProductSale([FromQuery] ProductSaleDTO productSaleDTO)
		{
			var ps = new ProductSale()
			{
				Id = Guid.NewGuid(),
				ProductId = productSaleDTO.ProdId,
				StartDate = productSaleDTO.StartDate,
				EndDate = productSaleDTO.EndDate,
				SaleRate = productSaleDTO.SlaeRate
			};
			await _context.ProductSales.AddAsync(ps);

			await _context.SaveChangesAsync();
			return new Resault<ProductSale>(true, "The offer has been added successfully", ps);
		}
	}
}
