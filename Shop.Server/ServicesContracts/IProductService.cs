using Shop.Server.Models;
using Shop.Server.Models.DTO;

namespace Shop.Server.ServicesContracts
{
	public interface IProductService
	{
		Task<List<Product>> GetProductsAsync(RequestDTO input);
		Task AddProduct(Product product);
		Task UpdateProduct(Product product);
		Task DeleteProduct(int prodId);
	}
}
