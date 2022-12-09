using System;
using System.Collections.Generic;

namespace B2CWebsite.Models;

public partial class TransactStatus
{
    public int TransactId { get; set; }

    public string? Status { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
