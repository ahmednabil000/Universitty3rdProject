

using System.ComponentModel.DataAnnotations;
using Shop.Server.Models;

public class ProductSale
{
    public Guid Id { get; set; }
    public string ProductId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    [Range(0, 100)]
    public float SaleRate { get; set; }
    public Product Product { get; set; }
}