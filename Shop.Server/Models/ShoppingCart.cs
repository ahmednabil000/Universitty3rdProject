namespace Shop.Server.Models
{
    public class ShoppingCart
    {
        public Guid Id { get; set; }
        public Guid UserID { get; set; }
        public List<ShoppingCartItem> Items { get; set; }

    }
}
