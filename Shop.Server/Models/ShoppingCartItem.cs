namespace Shop.Server.Models
{
	public class ShoppingCartItem
	{
		public Guid ID { get; set; }
		public Guid ShoppingCartID { get; set; }
		// public string ProductID { get; set; }
		// public int Quantity { get; set; }
		// public Product Product { get; set; }
		public ShoppingCart ShoppingCart { get; set; }
	}
}
