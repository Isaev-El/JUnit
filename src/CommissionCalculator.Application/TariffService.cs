using System.Text.Json;

namespace CommissionCalculator.Application;

public class TariffService
{
    public Tariff Load(string path)
    {
        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<Tariff>(json)
               ?? throw new Exception("Invalid JSON");
    }
}