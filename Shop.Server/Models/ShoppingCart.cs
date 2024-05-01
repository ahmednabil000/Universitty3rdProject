namespace Shop.Server.Models
{
    public class ShoppingCart
    {
        public Guid Id { get; set; }
        public Guid UserID { get; set; }
        public Decimal TotalCost { get; set; }
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

    }
}
