using System.ComponentModel.DataAnnotations;

namespace Customers_API.Core.Models.DTOs;

public class CreateOrderItemRequest
{

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Please enter valid doubleNumber")]
    public decimal Price { get; set; }
    
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Description { get; set; }
    
    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
    public int Quantity { get; set; }
    
}