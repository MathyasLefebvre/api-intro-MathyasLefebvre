using Customers_API.Core.Models.DTOs;
using Customers_API.Infrastructure;
using Customers_API.Infrastructure.Models;

namespace Customers_API.Core.Maper;

public static class OrderMapper
{

    public static OrderResponse OrderToDto(Order order)
    {
        return new OrderResponse
        {
            CustomerId = order.CustomerId,
            Country = order.Country,
            Street = order.Street,
            City = order.City,
            ZipCode = order.City,
            Total = order.Total,
        };
    }
    
    public static Customer OrderRequestToCustomer(CreateOrderRequest order)
    {
        return new Customer
        {
                Firstname = order.Customer.Firstname,
                Lastname = order.Customer.Lastname,
                Email = order.Customer.Email
        };
    }

    public static Order RequestToOrder(CreateOrderRequest request, Customer customer)
    {
        return new Order
        {
            Country = request.Country,
            Street = request.Street,
            City = request.City,
            ZipCode = request.ZipCode,
            Total = request.Total,
            Customer = customer
        };
    }
    
    public static OrderItem RequestToOrderItem(OrderItemResponse request, Order order)
    {
        
        return new OrderItem
        {
           Description = request.Description,
           Price = request.Price,
           Quantity = request.Quantity,
           Order = order
        };
    }

    public static StatsResponse OrderStatsToDto(DBContext dbContext)
    {
        return new StatsResponse
        {
            OrdersCount = JsonFileQuery.GetNumberOfOrders(dbContext),
            OrdersItemsCount = JsonFileQuery.GetNumberOfOrdersItems(dbContext),
            OrderedFromCanadaCount = JsonFileQuery.GetCanadaData(dbContext),
            OrderedFromOtherCountriesCount = JsonFileQuery.GetOtherCountryData(dbContext)
        };
    }
}