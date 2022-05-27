namespace Customers_API.Core.Models.DTOs;

public class OrderItemResponse
{

    public decimal Price { get; set; }
    
    public string Description { get; set; }
    
    public int Quantity { get; set; }
    
}