namespace CommissionCalculator.Domain;

public class CommissionCalculator
{
    public decimal Calculate(decimal amount, decimal percent, decimal min, decimal max)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive");

        var commission = amount * percent / 100m;

        if (commission < min)
            commission = min;

        if (commission > max)
            commission = max;

        return Math.Round(commission, 2);
    }
}