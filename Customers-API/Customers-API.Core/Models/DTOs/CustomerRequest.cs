using System.ComponentModel.DataAnnotations; 
namespace Customers_API.Core.Models.DTOs;

public class CustomerRequest
{
    [Required]
    [StringLength(50, MinimumLength = 1)]
    public string Firstname { get; set; }
    
    [Required]
    [StringLength(50, MinimumLength = 1)]
    public string Lastname { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}