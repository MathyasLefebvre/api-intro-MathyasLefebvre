using AutoMapper;
using Customers_API.Core.Interface;
using Customers_API.Core.Maper;
using Customers_API.Core.Models.DTOs;
using Customers_API.Infrastructure.Models;
using Customers_API.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Customers_API.Infrastructure.Repositories;

public class OrderRepository: IOrderRepository
{
    private DBContext _dbContext;
    private readonly object _locker = new();

    public OrderRepository(DBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IEnumerable<OrderResponse> GetOrder()
    {
        throw new NotImplementedException();
    }

    public OrderResponse GetOrderById(int id)
    {
        throw new NotImplementedException();
    }

    public void DeleteById(int id)
    {
        throw new NotImplementedException();
    }

    public OrderResponse CreateOrder(CreateOrderRequest orderRequest)
    {
        var customer = AddCustomer(orderRequest);
        var order = AddOrder(orderRequest, customer);
        AddOrderItem(orderRequest, order);
        var orderResponse = GetOrderResponse(order);
        UpdateInformation();
        return orderResponse;
    }

    public void UpdateOrder(CreateOrderRequest order)
    {
        throw new NotImplementedException();
    }

    public StatsResponse GetStatistic()
    {
        return OrderMapper.OrderStatsToDto(_dbContext);
    }

    private OrderResponse GetOrderResponse(Order order)
    {
        return OrderMapper.OrderToDto(order);
    }

    private Customer AddCustomer(CreateOrderRequest createOrderRequest)
    {
        var customer = OrderMapper.OrderRequestToCustomer(createOrderRequest);
        _dbContext.Customers.Add(customer);
        _dbContext.SaveChanges();
        return customer;
    }

    private Order AddOrder(CreateOrderRequest createOrderRequest, Customer customer)
    {
        var order = OrderMapper.RequestToOrder(createOrderRequest, customer);
        _dbContext.Orders.Add(order);
        _dbContext.SaveChanges();
        return order;
    }

    private void AddOrderItem(CreateOrderRequest createOrderRequest, Order order)
    {
        foreach (var item in createOrderRequest.OrderItems)
        {
            var orderItem = OrderMapper.RequestToOrderItem(item, order);
            _dbContext.OrderItems.Add(orderItem);
            _dbContext.SaveChanges();
        }
    }

    private void UpdateInformation()
    {
        lock (_locker)
        {
            JsonFileWriter writer = new JsonFileWriter(_dbContext);
            writer.WriteToJsonFile();
        }
    }
}