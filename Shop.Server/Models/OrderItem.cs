

using Shop.Server.Models;

public class OrderItem
{

    public Guid Id { get; set; }
    public string ProductId { get; set; }
    public Guid OrderId { get; set; }
    public int Quantity { get; set; }
    public virtual Product Product { get; set; }
    public virtual Order order { get; set; }
}