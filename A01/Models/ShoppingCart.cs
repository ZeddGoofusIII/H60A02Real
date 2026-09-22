namespace A01.Models
{
    public class ShoppingCart
    {
        public int CartId { get; set; }

        public int CustomerId { get; set; }

        public DateOnly DateCreated { get; set; }

        public virtual IEnumerable<CartItem> Items { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
