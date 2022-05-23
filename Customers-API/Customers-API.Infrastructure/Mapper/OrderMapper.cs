using Customers_API.Core.Models.DTOs;
using Customers_API.Infrastructure.Models;

namespace Customers_API.Core.Maper;

public static class OrderMapper
{
    public static CustomerResponse CustomerToDto(Customer customer)
        {
            return new CustomerResponse()
            {
                    CustomerId = customer.CustomerId,
                    Firstname = customer.Firstname,
                    Lastname = customer.Lastname,
                    Email = customer.Email
            };
        }
}