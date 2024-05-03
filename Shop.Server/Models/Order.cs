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
    public string Status { get; set; }
    [Required]
    public string PaymentMethod { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string Streat { get; set; }
    [Required]
    [Length(11, 11)]
    public string PhoneNumber { get; set; }
    [Required]
    public DateTime CreatedDate { get; set; }
    public virtual IdentityUser User { get; set; }
    public virtual List<OrderItem> Items { get; set; } = new List<OrderItem>();
}