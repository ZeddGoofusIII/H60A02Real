using System.Text.Json.Serialization;

namespace A01.Models
{
    public class Customer
    {
        [JsonPropertyName("customerId")]
        public int CustomerId   { get; set; }
        [JsonPropertyName("firstname")]
        public string? Firstname { get; set; }

        [JsonPropertyName("lastname")]
        public string? Lastname { get; set; }

        [JsonPropertyName("email")]     
        public string? Email { get; set; }
        [JsonPropertyName("phoneNumber")]
        public string? PhoneNumber { get; set; }

        [JsonPropertyName("province")]
        public string? Province { get; set; }

        [JsonPropertyName("creditCard")]
        public string? CreditCard {  get; set; }

        [JsonPropertyName("idCode")]
        public string? IdCode { get; set; } = null!;
        [JsonPropertyName("orders")]
        public virtual IEnumerable<Order>? Orders { get; set; }
        [JsonPropertyName("shoppingCart")]
        public virtual ShoppingCart? ShoppingCart { get; set; } = null!;
    }
}
