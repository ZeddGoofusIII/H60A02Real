using System;
using System.Collections.Generic;

namespace A01.model;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Province { get; set; }

    public string? CreditCard { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ShoppingCart? ShoppingCart { get; set; }
}
