namespace A01.Services;
using A01.models;
public class Validation
{
    public static void ValidateStock(int stock, Product product)
    {
        if (stock + product.Stock < 0)
        {
            throw new ArgumentException("Stock cannot be negative.");
        }
    }
}
