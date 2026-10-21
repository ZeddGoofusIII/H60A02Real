using System;
using System.Collections.Generic;

namespace A01.model;

public partial class ProductCategory
{
    public int ProductCategoryId { get; set; }

    public string ProdCat { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
