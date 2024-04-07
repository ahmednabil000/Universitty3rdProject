using System;
using System.Collections.Generic;

namespace Shop.Server.Models;

public partial class Product
{
    public int PId { get; set; }

    public string PName { get; set; } = null!;

    public int PPrice { get; set; }

    public string PDesc { get; set; } = null!;

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
