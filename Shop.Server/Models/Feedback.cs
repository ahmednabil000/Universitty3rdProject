using System;
using System.Collections.Generic;

namespace Shop.Server.Models;

public partial class Feedback
{
    public string CName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int CNumber { get; set; }

    public string City { get; set; } = null!;
}
