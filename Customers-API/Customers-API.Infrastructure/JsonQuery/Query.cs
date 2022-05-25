using System.Text.Json;
using Customers_API.Infrastructure.Models;

namespace Customers_API.Infrastructure;

public static class Query
{
    public static string GetCountryData(DBContext context)
    {
        var country = new Country
        {
                Canada = GetCanadaData(context),
                Other = GetOtherCountryData(context)
        };
        return JsonSerializer.Serialize(country);
    }
    
    public static string GetOrdersData(DBContext context)
    {
        var orders =  new NumberOrders
        {
                NumberOrder = GetNumberOfOrders(context),
                NumberOrderItem = GetNumberOfOrdersItems(context)
        };
        return JsonSerializer.Serialize(orders);
    }

    private static int GetCanadaData(DBContext context)
    {
        return context.Orders.Where(o => o.Country == "Canada")
                .Select(o => o.Country)
                .Count();
    }
    
    private static int GetOtherCountryData(DBContext context)
    {
        return context.Orders.Where(o => o.Country != "Canada")
                .Select(o => o.Country)
                .Count();
    }

    private static int GetNumberOfOrders(DBContext context)
    {
        return context.Orders.Select(o => o.OrderId).Count();
    }
    
    private static int GetNumberOfOrdersItems(DBContext context)
    {
        return context.OrderItems.Select(o => o.OrderItemId).Count();
    }
}