using System;
using System.Collections.Generic;

namespace Shop.Server.Models;

public partial class Customer
{
    public int CId { get; set; }

    public string CName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string RePassword { get; set; } = null!;

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
