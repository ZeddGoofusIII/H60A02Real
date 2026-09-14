using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace A01.models;

public partial class Product
{
    public int ProductId { get; set; }

    public int ProdCatId { get; set; }

    public string? Description { get; set; }

    public string? Manufacturer { get; set; }

    public int Stock { get; set; }

    public decimal? BuyPrice { get; set; }

    public decimal? SellPrice { get; set; }

    public virtual ProductCategory? ProdCat { get; set; } = null!;
}
