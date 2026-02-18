using CommissionCalculator.Application;

namespace CommissionCalculator.Tests;

public class TariffIntegrationTests
{
    [Fact]
    public void Load_ValidJson_ReturnsTariff()
    {
        var path = "tariff.json";
        File.WriteAllText(path, """
                                { "Percent": 2, "Min": 10, "Max": 100 }
                                """);

        var service = new TariffService();
        var tariff = service.Load(path);

        Assert.Equal(2, tariff.Percent);
        Assert.Equal(10, tariff.Min);
        Assert.Equal(100, tariff.Max);

        File.Delete(path);
    }

    [Fact]
    public void Load_InvalidJson_Throws()
    {
        var path = "bad.json";
        File.WriteAllText(path, "invalid json");

        var service = new TariffService();

        Assert.ThrowsAny<Exception>(() => service.Load(path));

        File.Delete(path);
    }
}