namespace Shop.Server.Models;

public class Product
{
    public string Id { get; set; }
    public string? CategoryId { get; set; }
    public string Name { get; set; } = null!;
    public decimal? Price { get; set; }

    public string? ImageUrl { get; set; }

    public string? Desc { get; set; } = null!;

    public int Quantity { get; set; }
    public Category category { get; set; }
    public List<Feedback> Feedbacks { get; set; }

}
