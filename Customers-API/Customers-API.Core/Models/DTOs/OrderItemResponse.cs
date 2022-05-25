namespace Customers_API.Core.Models.DTOs;

public class OrderItemResponse
{
    public int OrderItemId { get; set; }
    
    public decimal Price { get; set; }
    
    public string Description { get; set; }
    
    public int Quantity { get; set; }
    
    public int OrderId { get; set; }
}