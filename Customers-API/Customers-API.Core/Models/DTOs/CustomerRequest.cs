using System.ComponentModel.DataAnnotations; 
namespace Customers_API.Core.Models.DTOs;

public class CustomerRequest
{
    //[Required] 
    [Key]
    public int customer_id { get; set; }

    //[StringLength(50, MinimumLength = 1)]
    public string firstname { get; set; }
    
    //[StringLength(50, MinimumLength = 1)]
    public string lastname { get; set; }
    
    //[Required]
    //[EmailAddress]
    public string email { get; set; }
}