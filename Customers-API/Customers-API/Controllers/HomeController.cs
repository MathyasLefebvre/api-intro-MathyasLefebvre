using Customers_API.Core.Interface;
using Customers_API.Core.Models.DTOs;
using Customers_API.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Customers_API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class HomeController: ControllerBase
{
    private readonly ICustomerRepository _repository;

    public HomeController(ICustomerRepository repository)
    {
        _repository = repository; 
    }

    [HttpGet]
    [Route("customers")]
    public ActionResult<IEnumerable<CustomerResponse>> GetCustomer()
    {
        return Ok(_repository.GetCustomer());
    }

    [HttpGet]
    [Route("customer/{id}")]
    public ActionResult<CustomerResponse> GetCustomerById(int id)
    {
        return Ok(_repository.GetCustomerById(id));
    }

    [HttpDelete]
    public void DeleteById(int id)
    {
        _repository.DeleteById(id);
    }

    [HttpPost]
    public ActionResult<CustomerResponse> CreateCustomer(CreateCustomerRequest customer)
    {
        if (!ModelState.IsValid)
            return NotFound();
        return Ok(_repository.CreateCustomer(customer));
    }

    [HttpPut]
    public void UpdatePatientRecord(CreateCustomerRequest customer)
    {
        throw new NotImplementedException();
    }
}