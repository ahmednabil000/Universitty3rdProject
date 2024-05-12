using Shop.Server.Models;
using Shop.Server.Models.DTO;

namespace Shop.Server.ServicesContracts
{
	public interface IProductService
	{
		Task<Product> GetProductAsync(string productId);
		Task<List<Product>> GetProductsAsync(RequestDTO input);
		Task<Resault<Product>> AddProductAsync(Product product);
		Task<Resault<Product>> UpdateProductAsync(Product product);
		Task<Resault<Product>> DeleteProductAsync(string prodId);
		Task<Resault<ProductSale>> AddProductSale(ProductSaleDTO productSaleDTO);
	}
}
