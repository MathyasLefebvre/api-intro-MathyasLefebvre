namespace Customers_API.Core.Models.DTOs;

public class OrderResponse
{
    public virtual CustomerResponse Customer { get; set; }
    
    public int OrderId { get; set; }
    
    public int CustomerId { get; set; }
    
    public string Country { get; set; }
    
    public string Street { get; set; }
    
    public string City { get; set; }
    
    public string ZipCode { get; set; }
    
    public decimal Total { get; set; }

    public virtual ICollection<OrderItemResponse> OrderItems { get; set; }
}