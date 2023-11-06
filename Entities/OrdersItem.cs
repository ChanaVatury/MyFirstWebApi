using System;
using System.Collections.Generic;

namespace Entities;

public partial class OrdersItem
{
    public int OrderItemId { get; set; }

    public int? UserId { get; set; }

    public int? OrderId { get; set; }

    public int? Quantity { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? User { get; set; }
}
