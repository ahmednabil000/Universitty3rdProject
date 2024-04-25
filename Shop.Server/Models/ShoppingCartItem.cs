namespace Shop.Server.Models
{
	public class ShoppingCartItem
	{
		public int ID { get; set; }
		public int ShoppingCartID { get; set; }
		public int ProductID { get; set; }
		public int Quantity { get; set; }
		public Product Product { get; set; }
		public ShoppingCart ShoppingCart { get; set; }
	}
}
