using System.ComponentModel.DataAnnotations;

namespace Customers_API.Core.Models.DTOs;

public class CreateCustomerRequest
{

    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Firstname { get; set; }
    
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Lastname { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}