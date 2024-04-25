using Shop.Server.Models;
using Shop.Server.Models.DTO;

namespace Shop.Server.ServicesContracts
{
	public interface IProductService
	{
		Task<Product> GetProductAsync(Guid productId);
		Task<List<Product>> GetProductsAsync(RequestDTO input);
		Task AddProductAsync(Product product);
		Task UpdateProductAsync(Product product);
		Task DeleteProductAsync(Guid prodId);
	}
}
