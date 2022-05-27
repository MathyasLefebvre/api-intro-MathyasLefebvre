using Customers_API.Core.Interface;
using Customers_API.Core.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Customers_API.Controllers;

[ApiController]
public class OrdersControllerV1: ControllerBase
{
    private readonly IOrderRepository _repository;

    public OrdersControllerV1(IOrderRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    [Route("api/v1/stats")]
    public ActionResult<StatsResponse> GetStatistic()
    {
        return Ok(_repository.GetStatistic());
    }
    
    [HttpPost]
    [Route("api/v1/orders")]
    public ActionResult<OrderResponse> CreateCustomer(CreateOrderRequest order)
    {
        if (!ModelState.IsValid)
            return NotFound();
        return Ok(_repository.CreateOrder(order));
    }
}