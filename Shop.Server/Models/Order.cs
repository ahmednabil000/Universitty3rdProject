using Microsoft.AspNetCore.Identity;
using Shop.Server.Models;

public class Order
{
    public Guid Id { get; set; }
    public decimal TotalCost { get; set; }
    public Guid UserId { get; set; }
    public virtual IdentityUser User { get; set; }
    public virtual List<OrderItem> Items { get; set; } = new List<OrderItem>();
}