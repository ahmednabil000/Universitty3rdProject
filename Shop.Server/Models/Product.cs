namespace Shop.Server.Models;

public partial class Product
{
	public int PId { get; set; }

	public string PName { get; set; } = null!;

	public int PPrice { get; set; }

	public string PDesc { get; set; } = null!;

}
