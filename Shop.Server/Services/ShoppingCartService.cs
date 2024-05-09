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
        private readonly IProductService _productService;
        public ShoppingCartService(DbAa7408UniversityprojectContext context, IHttpContextAccessor httpContextAccessor, IProductService productService)
        {
            this._context = context;
            this._httpContextAccessor = httpContextAccessor;
            this._productService = productService;
        }

        public async Task<Resault<ShoppingCartItem>> AddShoppingCartItemAsync(string prodId, int quantity)
        {
            if (quantity <= 0) return new Resault<ShoppingCartItem>(false, "Quantity must be greater than 0", null);
            var prod = await _context.Products.FirstOrDefaultAsync(p => p.Id == prodId);
            if (prod == null) return new Resault<ShoppingCartItem>(false, $"There is no product with this id {prodId}", null);
            if (quantity > prod.Quantity) return new Resault<ShoppingCartItem>(false, $"Only {prod.Quantity} pieces of this product exist", null);

            var userId = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "user-id")?.ToString();

            var resault = await GetShoppingCartAsync();
            var cart = resault.Data;
            var item = new ShoppingCartItem()
            {
                ID = Guid.NewGuid(),
                ShoppingCartID = cart.Id,
                ProductID = prodId,
                Quantity = quantity,
            };

            cart.Items.Add(item);
            await _context.ShoppingCartItems.AddAsync(item);
            await _context.SaveChangesAsync();

            return new Resault<ShoppingCartItem>(true, "You have successfully added the product to your cart", item);
        }

        public async Task<Resault<ShoppingCart>> ClearShoppingCartAsync()
        {
            var res = await GetShoppingCartAsync();
            var cart = res.Data;
            if (cart.Items.Count == 0) return new Resault<ShoppingCart>(false, "Your cart is already clear", cart);
            _context.ShoppingCartItems.RemoveRange(cart.Items);
            await _context.SaveChangesAsync();
            return new Resault<ShoppingCart>(true, "Your cart has been cleard successfully", cart);
        }

        public async Task<Resault<ShoppingCart>> GetShoppingCartAsync()
        {
            var userId = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "user-id")?.Value?.ToString();

            var cart = await _context.ShoppingCarts.Include(s => s.Items).FirstOrDefaultAsync(c => c.UserID.ToString() == userId);

            if (cart == null)
            {
                cart = new ShoppingCart()
                {
                    Id = Guid.NewGuid(),
                    UserID = new Guid(userId!).ToString(),
                };
                await _context.ShoppingCarts.AddAsync(cart);
            }
            decimal totalCost = 0m;
            foreach (var item in cart.Items)
            {
                var offer = await _context.ProductSales.FirstOrDefaultAsync(ps => ps.ProductId == item.ProductID && ps.StartDate < DateTime.Now && ps.EndDate > DateTime.Now);
                var prod = await _productService.GetProductAsync(item.ProductID);
                if (prod != null)
                {
                    if (offer != null)
                    {
                        totalCost += ((decimal)prod.Price.Value / (decimal)offer.SaleRate);
                    }
                    else
                    {

                        totalCost += prod.Price.Value;
                    }
                }
            }
            cart.TotalCost = totalCost;
            return new Resault<ShoppingCart>(true, "Your shopping cart", cart);
        }

        public async Task RemoveShoppingCartItemAsync(Guid itemId)
        {
            var item = await _context.ShoppingCartItems.FirstOrDefaultAsync(i => i.ID == itemId);
            if (item != null)
            {
                _context.ShoppingCartItems.Remove(item);
                await _context.SaveChangesAsync();
            }

        }



        public async Task<Resault<ShoppingCartItem>> UpdateItemQuantityAsync(Guid itemId, int newQuantity)
        {
            if (newQuantity <= 0) return new Resault<ShoppingCartItem>(false, "Quantity must be greater than 0", null);

            var item = await _context.ShoppingCartItems.FirstOrDefaultAsync(i => i.ID == itemId);

            if (item == null) return new Resault<ShoppingCartItem>(false, "Cart Item not found", null);

            if (item != null)
            {
                item.Quantity = newQuantity;
            }
            _context.ShoppingCartItems.Update(item!);
            await _context.SaveChangesAsync();
            return new Resault<ShoppingCartItem>(true, "You have updated the item qquantity successfully", item);
        }
    }
}
