using System.Text.Json;
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

    public string GetJson()
    {
        var json = Query.GetCountryData(_context);
        json += "\n";
        json += Query.GetOrdersData(_context);
        return json;
    }
}