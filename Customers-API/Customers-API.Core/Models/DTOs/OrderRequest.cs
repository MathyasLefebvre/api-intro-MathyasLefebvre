using System.ComponentModel.DataAnnotations; 
namespace Customers_API.Core.Models.DTOs;

public class OrderRequest
{
    [Required]
    [StringLength(50, MinimumLength = 1)]
    public string Country { get; set; }
    
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Street { get; set; }
    
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string City { get; set; }
    
    [Required]
    [StringLength(6)]
    public string ZipCode { get; set; }
    
    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Please enter valid doubleNumber")]
    public double Total { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}