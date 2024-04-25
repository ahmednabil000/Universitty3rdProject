using System.Net.Http.Headers;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shop.Server.Models;
using Shop.Server.ServicesContracts;

namespace Shop.Server.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly DbAa7408UniversityprojectContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ShoppingCartService(DbAa7408UniversityprojectContext context, IHttpContextAccessor httpContextAccessor)
        {
            this._context = context;
            this._httpContextAccessor = httpContextAccessor;
        }

        public async Task AddShoppingCartItemAsync(ShoppingCartItem item)
        {
            var userId = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "user-id")?.ToString();

            var cart = await GetShoppingCartAsync(new Guid(userId));
            item.ID = Guid.NewGuid();
            item.ShoppingCartID = cart.Id;

            cart.Items.Add(item);
            await _context.ShoppingCartItems.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task AddShoppingCartItemsAsync(List<ShoppingCartItem> items)
        {
            var userId = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "user-id")?.ToString();

            var cart = await GetShoppingCartAsync(new Guid(userId));
            foreach (var item in items)
            {
                item.ID = Guid.NewGuid();
                item.ShoppingCartID = cart.Id;
            }

            cart.Items.AddRange(items);
            await _context.ShoppingCartItems.AddRangeAsync(items);
            await _context.SaveChangesAsync();
        }

        public async Task<ShoppingCart> GetShoppingCartAsync(Guid userId)
        {
            var cart = await _context.ShoppingCarts.FirstAsync(c => c.UserID == userId);

            if (cart == null)
            {
                await _context.ShoppingCarts.AddAsync(new ShoppingCart()
                {
                    Id = Guid.NewGuid(),
                    UserID = userId,
                });
            }

            return cart != null ? cart : new ShoppingCart();
        }

        public async Task RemoveShoppingCartItem(Guid itemId)
        {
            var item = await _context.ShoppingCartItems.FirstOrDefaultAsync(i => i.ID == itemId);
            if (item != null)
            {
                _context.ShoppingCartItems.Remove(item);
                await _context.SaveChangesAsync();
            }

        }

        public async Task UpdateItemQuantity(Guid itemId, int newQuantity)
        {
            var item = await _context.ShoppingCartItems.FirstOrDefaultAsync(i => i.ID == itemId);

            if (item != null)
            {
                item.Quantity = newQuantity;
            }
            _context.ShoppingCartItems.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
