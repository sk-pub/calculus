namespace Calculus.Api.Calculators.Electricity;

public class ElectricityCalculationResult : ICalculationResult
{
    public ElectricityCalculationResult(string name, decimal annualCosts)
    {
        Name = name;
        AnnualCosts = annualCosts;
    }

    public string Name { get; }

    public decimal AnnualCosts { get; }
}
