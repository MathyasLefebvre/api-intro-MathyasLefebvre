namespace Customers_API.Infrastructure.Models;

public class Stats
{
    public int OrdersCount { get; set; }

    public int OrdersItemsCount { get; set; }

    public int OrderedFromCanadaCount { get; set; }

    public int OrderedFromOtherCountriesCount { get; set; }
}