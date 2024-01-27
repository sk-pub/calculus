using Calculus.Api.Products;

namespace Calculus.Api.Calculators.Electricity;

public class ElectricityCalculator : ICalculator<ElectricityCalculationParameters, ElectricityCalculationResult>
{
    public HashSet<Type> SupportedProducts => [typeof(BasicElectricity), typeof(PackagedElectricity)];

    public ElectricityCalculationResult Calculate(IProduct product, ElectricityCalculationParameters parameters)
    {
        switch (product)
        {
            case PackagedElectricity packagedElectricity:
                return CalculatePackagedElectricity(parameters, packagedElectricity);
            case BasicElectricity basicElectricity:
                return CalculateBasicElectricity(parameters, basicElectricity);
            default:
                throw new NotSupportedException();
        }
    }

    private static ElectricityCalculationResult CalculatePackagedElectricity(ElectricityCalculationParameters parameters, PackagedElectricity packagedElectricity)
    {
        return new ElectricityCalculationResult(
                packagedElectricity.Name,
                packagedElectricity.BaseCost
                    + packagedElectricity.AdditionalKwhCost * Math.Max(0, parameters.YearlyConsumption - packagedElectricity.IncludedKwh)
            );
    }

    private static ElectricityCalculationResult CalculateBasicElectricity(ElectricityCalculationParameters parameters, BasicElectricity basicElectricity)
    {
        return new ElectricityCalculationResult(
                basicElectricity.Name,
                basicElectricity.BaseCost * 12 + basicElectricity.AdditionalKwhCost * parameters.YearlyConsumption
            );
    }
}
