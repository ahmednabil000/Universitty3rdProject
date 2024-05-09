using Shop.Server.Models;
using Shop.Server.Models.DTO;

namespace Shop.Server.ServicesContracts
{
	public interface IProductService
	{
		Task<Product> GetProductAsync(string productId);
		Task<List<Product>> GetProductsAsync(RequestDTO input);
		Task AddProductAsync(Product product);
		Task UpdateProductAsync(Product product);
		Task DeleteProductAsync(string prodId);
		Task<Resault<ProductSale>> AddProductSale(ProductSaleDTO productSaleDTO);
	}
}
