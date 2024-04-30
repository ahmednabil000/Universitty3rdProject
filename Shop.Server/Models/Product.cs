namespace Shop.Server.Models;

public partial class Product
{
    public string Id { get; set; }

    public string PName { get; set; } = null!;

    public decimal PPrice { get; set; }

    public string PDesc { get; set; } = null!;

    public int Quantity { get; set; }

}
