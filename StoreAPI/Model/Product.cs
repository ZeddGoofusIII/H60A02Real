using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace StoreAPI.Model;

public partial class Product
{
    public int ProductId { get; set; }

    public int ProductCategoryId { get; set; }

    public string? Description { get; set; }

    public string? Manufacturer { get; set; }

    public int Stock { get; set; }

    public decimal? BuyPrice { get; set; }

    public decimal? SellPrice { get; set; }

    public string? ProdCat { get; set; } = null!;

    public Product(int productId)
    {
        ProductId = productId;
    }

    public Product(int productId, int productCategoryId, string? description, string? manufacturer, int stock, decimal? buyPrice, decimal? sellPrice)
    {
        ProductId = productId;
        ProductCategoryId = productCategoryId;
        Description = description;
        Manufacturer = manufacturer;
        Stock = stock;
        BuyPrice = buyPrice;
        SellPrice = sellPrice;
    }

    public Product(int productCategoryId, string? description, string? manufacturer, int stock, decimal? buyPrice, decimal? sellPrice)
    {
        ProductCategoryId = productCategoryId;
        Description = description;
        Manufacturer = manufacturer;
        Stock = stock;
        BuyPrice = buyPrice;
        SellPrice = sellPrice;
    }

    public Product()
    {

    }
}
