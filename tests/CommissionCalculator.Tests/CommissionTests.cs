namespace CommissionCalculator.Tests;

public class CommissionTests
{
    private readonly Domain.CommissionCalculator _calc = new();

    [Fact]
    public void Calculate_NormalAmount_ReturnsCorrect()
    {
        var result = _calc.Calculate(1000, 2, 10, 100);
        Assert.Equal(20, result);
    }

    [Fact]
    public void Calculate_MinLimit_AppliesMin()
    {
        var result = _calc.Calculate(100, 1, 10, 100);
        Assert.Equal(10, result);
    }

    [Fact]
    [Trait("Category", "Unit")]
    public void Calculate_MaxLimit_AppliesMax()
    {
        var result = _calc.Calculate(10000, 5, 10, 100);
        Assert.Equal(120, result);
    }

    [Fact]
    public void Calculate_RoundsCorrectly()
    {
        var result = _calc.Calculate(333, 1.5m, 0, 100);
        Assert.Equal(Math.Round(333 * 0.015m, 2), result);
    }

    [Fact]
    public void Calculate_LargeAmount_Works()
    {
        var result = _calc.Calculate(1_000_000, 1, 10, 100_000);
        Assert.Equal(10000, result);
    }

    [Fact]
    public void Calculate_ExactLimit_ReturnsExact()
    {
        var result = _calc.Calculate(500, 2, 10, 10);
        Assert.Equal(10, result);
    }

    //Negative test
    [Fact]
    public void Calculate_NegativeAmount_Throws()
    {
        Assert.Throws<ArgumentException>(() =>
            _calc.Calculate(-100, 2, 10, 100));
    }
}
