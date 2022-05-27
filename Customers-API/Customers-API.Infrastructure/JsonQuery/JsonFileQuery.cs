using System.Text.Json;
using Customers_API.Infrastructure.Models;

namespace Customers_API.Infrastructure;

public static class JsonFileQuery
{
    public static Country GetCountryData(DBContext context)
    {
        return new Country
        {
                Canada = GetCanadaData(context),
                Other = GetOtherCountryData(context)
        };
    }
    
    public static NumberOrders GetOrdersData(DBContext context)
    {
        return new NumberOrders
        {
                NumberOrder = GetNumberOfOrders(context),
                NumberOrderItem = GetNumberOfOrdersItems(context)
        };
    }

    public static int GetCanadaData(DBContext context)
    {
        return context.Orders.Where(o => o.Country == "Canada")
                .Select(o => o.Country)
                .Count();
    }
    
    public static int GetOtherCountryData(DBContext context)
    {
        return context.Orders.Where(o => o.Country != "Canada")
                .Select(o => o.Country)
                .Count();
    }

    public static int GetNumberOfOrders(DBContext context)
    {
        return context.Orders.Select(o => o.OrderId).Count();
    }
    
    public static int GetNumberOfOrdersItems(DBContext context)
    {
        return context.OrderItems.Select(o => o.OrderItemId).Count();
    }
}