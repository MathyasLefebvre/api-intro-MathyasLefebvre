using System.ComponentModel.DataAnnotations; 
namespace Customers_API.Core.Models.DTOs;

public class ItemRequest
{
    //[Required]
    [Key]
    public int order_item_id { get; set; }

    //[Required]
    //[Range(0, double.MaxValue, ErrorMessage = "Please enter valid doubleNumber")]
    public double price { get; set; }
    
    //[Required]
    //[StringLength(100, MinimumLength = 1)]
    public string description { get; set; }
    
    //[Required]
    //[Range(0, int.MaxValue, ErrorMessage = "Please enter valid intNumber")]
    public int quantity { get; set; }

    public int order_id { get; set; }
}