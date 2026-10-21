using System;
using System.Collections.Generic;

namespace A01.model;

public partial class CartItem
{
    public int CartItemId { get; set; }

    public int CartId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public int? ShoppingCartCartId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual ShoppingCart? ShoppingCartCart { get; set; }
}
