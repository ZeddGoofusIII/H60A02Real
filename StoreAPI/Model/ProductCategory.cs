using System;
using System.Collections.Generic;

namespace StoreAPI.Model;
public partial class ProductCategory
{
    public int ProductCategoryId { get; set; }

    public string? ProdCat { get; set; }

    public virtual ICollection<Product?>? Products { get; set; } = null!;

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
