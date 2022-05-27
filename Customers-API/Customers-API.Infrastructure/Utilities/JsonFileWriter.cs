using System.Text.Json;
using System.Xml;
using Customers_API.Infrastructure.Models;

namespace Customers_API.Infrastructure.Utilities;

public class JsonFileWriter
{
    private const string _PATH = "/order_stats.json";
    private DBContext _context;
    
    public JsonFileWriter(DBContext context)
    {
        _context = context;
    }
    
    public void WriteToJsonFile()
    {
        string json = JsonSerializer.Serialize(GetJson());
        File.WriteAllText(Directory.GetCurrentDirectory() + _PATH, json);
    }

    public OrderStatsJson GetJson()
    {
        return new OrderStatsJson
        {
            Country = JsonFileQuery.GetCountryData(_context),
            Stats = JsonFileQuery.GetOrdersData(_context)
        };
    }
}