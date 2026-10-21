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

    public static void ValidatePrice(PriceHelper helper)
    {
        if(helper.SellPrice < helper.BuyPrice)
        {
            throw new ArgumentException("Sell Price must be higher than buy price");
        }
        if(helper.SellPrice < 0 || helper.BuyPrice < 0)
        {
            throw new ArgumentException("Prices can not be negative");
        }
    }

    public static void ValidateStock(int newStock, global::StoreAPI.Model.Product product)
    {
        throw new NotImplementedException();
    }

    public static void ValidateStock(int newStock, global::StoreAPI.Model.Product product)
    {
        throw new NotImplementedException();
    }
}
