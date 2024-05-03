




using Microsoft.Identity.Client;
using Shop.Server.Models;

public class Category
{

    public string Id { get; set; }
    public string Name { get; set; }
    public List<Product> Products { get; set; }

}