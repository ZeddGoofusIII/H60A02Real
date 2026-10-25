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

        public string? IdCode { get; set; } = null!;

        public virtual IEnumerable<Order>? Orders { get; set; } = null!;

        public virtual ShoppingCart? ShoppingCart { get; set; } = null!;

        public Customer(int customerId)
        {
            CustomerId = customerId;
        }

        public Customer(int customerId, string? firstname, string? lastname, string? email, string? phoneNumber, string? province, string? creditCard, string? idCode)
        {
            CustomerId = customerId;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            PhoneNumber = phoneNumber;
            Province = province;
            CreditCard = creditCard;
            IdCode = idCode;
        }

        public Customer()
        {
        }
    }
}
