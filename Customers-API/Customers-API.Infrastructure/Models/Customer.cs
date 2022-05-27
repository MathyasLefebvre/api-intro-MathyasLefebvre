using System;
using System.Collections.Generic;

namespace Customers_API.Infrastructure.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
