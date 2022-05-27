using System.Configuration;
using Customers_API.Core.Interface;
using Customers_API.Infrastructure.Models;
using Customers_API.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Customers_API.Infrastructure.Dependency;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration builderConfiguration)
    {
        var defaultConnectionString = builderConfiguration.GetConnectionString("ConnectionString");
        services.AddDbContext<DBContext>(options =>
        {
            if (defaultConnectionString != null) options.UseNpgsql(defaultConnectionString);
        });
        services.AddScoped<IOrderRepository, OrderRepository>();
        return services;
    }
}