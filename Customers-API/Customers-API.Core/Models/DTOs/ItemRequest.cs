using System.ComponentModel.DataAnnotations; 
namespace Customers_API.Core.Models.DTOs;

public class ItemRequest
{
    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Please enter valid doubleNumber")]
    public double Price { get; set; }
    
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string Description { get; set; }
    
    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Please enter valid intNumber")]
    public int Quantity { get; set; }
}