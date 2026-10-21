using Microsoft.Data.SqlClient;

namespace A01.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public int CustomerId  { get; set; }

        public DateOnly DateCreated { get; set; }

        public DateOnly DateFulfilled { get; set; }

        public float Total {  get; set; }

        public float taxes { get; set; }

        public virtual IEnumerable<OrderItem>? OrderItems { get; set; } = null;

        public virtual Customer? Customer { get; set; }
    }
}
