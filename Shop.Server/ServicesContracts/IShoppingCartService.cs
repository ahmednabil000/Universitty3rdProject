using Shop.Server.Models;
using Shop.Server.Models.DTO;

namespace Shop.Server.ServicesContracts
{

    public interface IShoppingCartService
    {
        Task<Resault<ShoppingCart>> GetShoppingCartAsync();
        Task<Resault<ShoppingCartItem>> AddShoppingCartItemAsync(string prodId, int quantity);
        Task RemoveShoppingCartItemAsync(Guid itemId);
        Task<Resault<ShoppingCart>> ClearShoppingCartAsync();
        Task<Resault<ShoppingCartItem>> UpdateItemQuantityAsync(Guid itemId, int newQuantity);

    }
}