using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customers_API.Core.Models.DTOs;

public class CreateOrderRequest
{
    [Required]
    public virtual CustomerResponse Customer { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Country { get; set; }
    
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Street { get; set; }
    
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string City { get; set; }
    
    [Required]
    [StringLength(7, MinimumLength = 6)]
    public string ZipCode { get; set; }
    
    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Please enter valid doubleNumber")]
    public decimal Total { get; set; }

    [Required]
    public virtual ICollection<OrderItemResponse> OrderItems { get; set; }
}