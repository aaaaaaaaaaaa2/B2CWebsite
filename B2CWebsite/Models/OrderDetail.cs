﻿namespace B2CWebsite.Models;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int? OrderId { get; set; }

    public int? Sid { get; set; }

    public int? OrderNumber { get; set; }

    public int? Quantity { get; set; }

    public int? Discount { get; set; }

    public int? Total { get; set; }

    public DateTime? ShipDate { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Supplement? SidNavigation { get; set; }
}