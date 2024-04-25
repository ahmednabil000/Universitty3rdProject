namespace Shop.Server.Models
{
	public class ShoppingCart
	{
        public int ID { get; set; }
        public int USerID { get; set; }
        LinkedList<ShoppingCartItem>? Items { get; set; }

    }
}
