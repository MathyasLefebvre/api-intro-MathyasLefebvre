using Customers_API.Core.Interface;
using Customers_API.Core.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Customers_API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class OrdersControllerV1: ControllerBase
{
    private readonly IOrderRepository _repository;

    public OrdersControllerV1(IOrderRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public void GetApiInformation()
    {
        
    }
    
    [HttpPost]
    public ActionResult<OrderResponse> CreateCustomer(CreateOrderRequest order)
    {
        if (!ModelState.IsValid)
            return NotFound();
        return Ok(_repository.CreateOrder(order));
    }
}