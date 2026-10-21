using StoreAPI.Model;

namespace StoreAPI.Model
{
    public class CartItem
    {
        public int CartItemId { get; set; }

        public int CartId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }

        public virtual Product? Product { get; set; }
    }
}
