namespace Shop.Server.Models;

public partial class Bill
{
	public int BId { get; set; }

	public int? PId { get; set; }

	public int? CId { get; set; }

	public string PName { get; set; } = null!;

	public string CName { get; set; } = null!;

	public virtual Customer? Customer { get; set; }

	public virtual Product? Product { get; set; }
}
