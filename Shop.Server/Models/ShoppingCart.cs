using Microsoft.AspNetCore.Identity;

namespace Shop.Server.Models
{
    public class ShoppingCart
    {
        public Guid Id { get; set; }
        public string UserID { get; set; }
        public Decimal TotalCost { get; set; }
        public IdentityUser User { get; set; }
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

    }
}
