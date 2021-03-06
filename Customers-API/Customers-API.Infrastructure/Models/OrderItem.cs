using System;
using System.Collections.Generic;

namespace Customers_API.Infrastructure.Models
{
    public partial class OrderItem
    {
        public int OrderItemId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public int Quantity { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; } = null!;
    }
}
