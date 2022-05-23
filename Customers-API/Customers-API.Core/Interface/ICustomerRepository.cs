
using Customers_API.Core.Models.DTOs;

namespace Customers_API.Core.Interface;

public interface ICustomerRepository
{
    IEnumerable<CustomerResponse> GetCustomer();
    
    CustomerResponse GetCustomerById(int id);
    
    void DeleteById(int id);
    
    void CreateCustomer(CreateCustomerRequest customer);
    
    void UpdateCustomer(CreateCustomerRequest customer); 
}