
namespace Shop.Server.ServicesContracts
{
    public interface IOrderService
    {
        Task<Resault<Order>> CreateOrderAsync(OrderDTO orderDTO);
        Task<Resault<Order>> RemoveOrder(Guid orderId);
        Task<Resault<List<Order>>> GetOrders();
        Task<Resault<Order>> GetOrderDetails(Guid orderId);
        Task<Resault<Order>> ConfirmOrderAsCompletedAsync(Guid orderId);
        Task<Resault<Order>> ConfirmOrderAsDeliverdAsync(Guid orderId);
    }
}