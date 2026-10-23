using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace A01.models;

public partial class ProductCategory
{
    [JsonPropertyName("productCategoryId")]
    public int ProductCategoryId { get; set; }
    [JsonPropertyName("prodCat")]
    public string ProdCat { get; set; } = null!;
    [JsonPropertyName("products")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public ProductCategory() { }

    public ProductCategory(int productCategoryId)
    {
        ProductCategoryId = productCategoryId;
    }

    public ProductCategory(string prodCat)
    {
        ProdCat = prodCat;
    }

    public ProductCategory(int productCategoryId, string prodCat)
    {
        ProdCat = prodCat;
        ProductCategoryId = productCategoryId;
    }
}
