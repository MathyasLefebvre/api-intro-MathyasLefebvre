namespace Customers_API.Core.Models.DTOs;

public class StatsResponse
{
    public int OrdersCount { get; set; }

    public int OrdersItemsCount { get; set; }

    public int OrderedFromCanadaCount { get; set; }

    public int OrderedFromOtherCountriesCount { get; set; }
}