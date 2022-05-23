using Customers_API.Core.Interface;
using Customers_API.Core.Maper;
using Customers_API.Core.Models.DTOs;
using Customers_API.Infrastructure.Models;

namespace Customers_API.Infrastructure.Repositories;

public class CustomerRepository: ICustomerRepository
{
    private DBContext _context;
    
    public CustomerRepository(DBContext context)
    {
        _context = context;
    }
    
    public IEnumerable<CustomerResponse> GetCustomer()
    {
        throw new NotImplementedException();
    }

    public CustomerResponse GetCustomerById(int id)
    {
        var customerQuery = _context.Customers.Where(customer => customer.CustomerId == id);
        var customer = customerQuery.First();
        var response = OrderMapper.CustomerToDto(customer);
        return response;
    }

    public async void DeleteById(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer is not null)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }

    public void CreateCustomer(CreateCustomerRequest customer)
    {
        throw new NotImplementedException();
    }

    public void UpdateCustomer(CreateCustomerRequest customer)
    {
        throw new NotImplementedException();
    }
}