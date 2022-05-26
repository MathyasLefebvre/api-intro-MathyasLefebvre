using Customers_API.Core.Models.DTOs;

namespace Customers_API.Core.Interface;

public interface IOrderRepository
{
    IEnumerable<OrderResponse> GetOrder();
    
    OrderResponse GetOrderById(int id);
    
    void DeleteById(int id);
    
    OrderResponse CreateOrder(CreateOrderRequest order);
    
    void UpdateOrder(CreateOrderRequest order);

    StatsResponse GetStatistic();
}