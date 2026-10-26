using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace A01.Models
{

    public enum Province
    {
        Alberta,
        BritishColumbia,
        Manitoba,
        NewBrunswick,
        NewfoundlandAndLabrador,
        NovaScotia,
        Ontario,
        PrinceEdwardIsland,
        Quebec,
        Saskatchewan
    }
    public class Customer
    {
        [JsonPropertyName("customerId")]
        public int CustomerId   { get; set; }
        [RegularExpression(@"^[A-Z][a-zA-Z]*$", ErrorMessage = "Firstname must start with an uppercase letter and contain only letters.")]
        [JsonPropertyName("firstname")]
        public string? Firstname { get; set; }

        [JsonPropertyName("lastname")]
        [RegularExpression(@"^[A-Z][a-zA-Z]*$", ErrorMessage = "Lastname must start with an uppercase letter and contain only letters.")]
        public string? Lastname { get; set; }

        [JsonPropertyName("email")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }
        [JsonPropertyName("phoneNumber")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be a 10-digit number.")]
        public string? PhoneNumber { get; set; }

        [JsonPropertyName("province")]
        public Province? Province { get; set; }

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
