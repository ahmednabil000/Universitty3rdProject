
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shop.Server.Models;
using Shop.Server.ServicesContracts;

namespace Shop.Server.Services
{

    public class OrderService : IOrderService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly DbAa7408UniversityprojectContext _context;
        public OrderService(IHttpContextAccessor contextAccessor, DbAa7408UniversityprojectContext context, IShoppingCartService shoppingCartService)
        {
            _contextAccessor = contextAccessor;
            _context = context;
            _shoppingCartService = shoppingCartService;
        }
        public async Task<Resault<Order>> ConfirmOrderAsCompletedAsync(Guid orderId)
        {
            var userId = _contextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "user-id")?.Value;
            var res = await GetOrderDetails(orderId);
            if (!res.IsSucceed) return res;

            var order = res.Data;
            order.Status = OrderStatus.Completed;
            _context.Orders.Update(order);

            await _context.SaveChangesAsync();
            return new Resault<Order>(true, "Order has been updated to completed", order);
        }

        public async Task<Resault<Order>> ConfirmOrderAsDeliverdAsync(Guid orderId)
        {
            var userId = _contextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "user-id")?.Value;
            var res = await GetOrderDetails(orderId);
            if (!res.IsSucceed) return res;

            var order = res.Data;
            var purchasedProds = new List<UsersPurchasedProducts>();
            order.Status = OrderStatus.Deliverd;
            _context.Orders.Update(order);
            foreach (var item in order.Items)
            {
                purchasedProds.Add(
                 new UsersPurchasedProducts()
                 {
                     Id = Guid.NewGuid(),
                     UserId = userId,
                     ProudctId = item.ProductId,
                 }
               );
            }
            await _context.UserPurchasedProducts.AddRangeAsync(purchasedProds);
            await _context.SaveChangesAsync();
            return new Resault<Order>(true, "Order has been updated to Deliverd", order);
        }

        public async Task<Resault<Order>> CreateOrderAsync(OrderDTO orderDTO)
        {
            var userId = _contextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "user-id")?.Value;
            var res = await _shoppingCartService.GetShoppingCartAsync();
            var cart = res.Data;

            if (cart!.Items.Count == 0) return new Resault<Order>(false, "Your cart is empty", null);

            var orderItems = new List<OrderItem>();

            var order = new Order()
            {
                Id = Guid.NewGuid(),
                UserId = new Guid(userId).ToString(),
                Items = orderItems,
                PhoneNumber = orderDTO.PhoneNumber,
                Streat = orderDTO.Streat,
                City = orderDTO.City,
                PaymentMethod = PaymentMethod.OnDelivery,
                Status = OrderStatus.Processing,
                Type = orderDTO.OrderType,
                CreatedDate = DateTime.Now,
                TotalCost = cart.TotalCost
            };

            foreach (var item in cart.Items)
            {
                orderItems.Add(new OrderItem()
                {
                    Id = Guid.NewGuid(),
                    ProductId = item.ProductID,
                    Quantity = item.Quantity,
                    OrderId = order.Id
                });
            }
            using (var transaction = _context.Database.BeginTransaction())
            {
                await _shoppingCartService.ClearShoppingCartAsync();
                await _context.Orders.AddAsync(order);
                await _context.OrderItems.AddRangeAsync(orderItems);
                await _context.SaveChangesAsync();
                transaction.Commit();
            }

            return new Resault<Order>(true, "Order has been created successfully", order);
        }

        public async Task<Resault<Order>> GetOrderDetails(Guid orderId)
        {
            var order = await _context.Orders.Include(o => o.Items).FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null) return new Resault<Order>(false, "Order not found", null);

            return new Resault<Order>(true, "Your order", order);
        }

        public async Task<Resault<List<Order>>> GetOrders()
        {
            var userId = _contextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "user-id")?.Value;
            var orders = await _context.Orders.Where(o => o.UserId.ToString() == userId).ToListAsync();

            if (orders.IsNullOrEmpty()) return new Resault<List<Order>>(false, "You don`t have any orders yet", orders);

            return new Resault<List<Order>>(true, "Your orders", orders);
        }

        public async Task<Resault<Order>> RemoveOrder(Guid orderId)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
            if (order == null) return new Resault<Order>(false, "Order not fount", null);

            var userId = _contextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "user-id")?.Value;

            if (order.UserId.ToString() != userId) return new Resault<Order>(false, $"You don`t have the permission to remove the order with id {orderId}", null);
            if (order.Status == OrderStatus.Completed) return new Resault<Order>(false, "You can`t remove this order because it is in the way to you", order);
            _context.Orders.Remove(order);
            return new Resault<Order>(true, $"Order with id {orderId} has been removed successfully", order);
        }
    }
}