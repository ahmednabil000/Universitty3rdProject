using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using Microsoft.AspNetCore.Identity;
using Shop.Server.Models;

public class Order
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public decimal TotalCost { get; set; }
    [Required]
    [ForeignKey(nameof(User))]
    public string UserId { get; set; }
    [Required]
    [AllowedValues(OrderStatus.Completed, OrderStatus.Deliverd, OrderStatus.Processing, ErrorMessage = "Invalid Order Status order status must be processing, completed or deliverd")]
    public string Status { get; set; }
    [Required]
    [AllowedValues(OrderTypes.PurchaseOrder, OrderTypes.ReturnOrder, ErrorMessage = "Invalid Order Type order type must be purchase or return")]
    public string Type { get; set; }
    [Required]
    public string PaymentMethod { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string Streat { get; set; }
    [Required]
    [Length(11, 11)]
    [PhoneNumber(ErrorMessage = "Invalid Phone Number")]
    public string PhoneNumber { get; set; }
    [Required]
    public DateTime CreatedDate { get; set; }
    public virtual IdentityUser User { get; set; }
    public virtual List<OrderItem> Items { get; set; } = new List<OrderItem>();
}