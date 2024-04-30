using Shop.Server.Models;
using Shop.Server.Models.DTO;

namespace Shop.Server.ServicesContracts
{

    public interface IShoppingCartService
    {
        Task<ShoppingCart> GetShoppingCartAsync();
        Task AddShoppingCartItemAsync(ShoppingCartItem item);
        Task AddShoppingCartItemsAsync(List<ShoppingCartItem> items);

        Task RemoveShoppingCartItem(Guid itemId);
        Task UpdateItemQuantity(Guid itemId, int newQuantity);

    }
}