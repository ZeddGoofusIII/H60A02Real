using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace A01.models;

public partial class Product
{
    [JsonPropertyName("productId")]
    public int ProductId { get; set; }
    [JsonPropertyName("productCategoryId")]
    public int ProductCategoryId { get; set; }
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    [JsonPropertyName("manufacturer")]
    public string? Manufacturer { get; set; }
    [JsonPropertyName("stock")]
    public int Stock { get; set; }
    [JsonPropertyName("buyPrice")]
    public decimal? BuyPrice { get; set; }
    [JsonPropertyName("sellPrice")]
    public decimal? SellPrice { get; set; }
    [JsonPropertyName("prodCat")]
    public string ProdCat { get; set; } = null!;

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
