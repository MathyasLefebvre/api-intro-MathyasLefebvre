using System.ComponentModel.DataAnnotations; 
namespace Customers_API.Core.Models.DTOs;

public class OrderRequest
{
    [Key]
    public int order_id { get; set; }
    
    public int customer_id { get; set; }

    //[StringLength(50, MinimumLength = 1)]
    public string country { get; set; }
    
    //[StringLength(100, MinimumLength = 3)]
    public string street { get; set; }
    
    //[StringLength(50, MinimumLength = 3)]
    public string city { get; set; }
    
    //[Required]
    //[StringLength(6)]
    public string zip_code { get; set; }
    
    //[Required]
    //[Range(0, double.MaxValue, ErrorMessage = "Please enter valid doubleNumber")]
    public double total { get; set; }
    
    //[Required]
    //[EmailAddress]
  
}