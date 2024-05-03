

using Microsoft.AspNetCore.Identity;
using Shop.Server.Models;

public class UsersPurchasedProducts
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public string ProudctId { get; set; }
    public IdentityUser User { get; set; }
    public Product Product { get; set; }
}