namespace Calculus.Api.Calculators.Electricity;

public class ElectricityCalculationParameters : ICalculationParameters
{
    public ElectricityCalculationParameters(int yearlyConsumption)
    {
        YearlyConsumption = yearlyConsumption;
    }

    public int YearlyConsumption { get; }
}
