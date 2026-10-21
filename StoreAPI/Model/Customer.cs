namespace StoreAPI.Model
{
    public class Customer
    {
        public int CustomerId   { get; set; }

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Province { get; set; }

        public string? CreditCard {  get; set; }

        public virtual IEnumerable<Order>? Orders { get; set; }

        public virtual ShoppingCart? ShoppingCart { get; set; } = null!;
    }
}
