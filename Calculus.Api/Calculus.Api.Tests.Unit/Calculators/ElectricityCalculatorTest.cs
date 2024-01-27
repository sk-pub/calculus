using Calculus.Api.Calculators.Electricity;
using Calculus.Api.Products;

namespace Calculus.Api.Tests.Unit.Products;

[TestClass]
public class ElectricityCalculatorTest
{
    [TestMethod]
    [DataRow(3500, 830)]
    [DataRow(4500, 1050)]
    public void GivenBasicElectricity_WhenCalculated_ReturnsExpectedResult(int yearlyConsumption, float annualCosts)
    {
        var basicElectricity = new BasicElectricity("Product A", 5, 22);

        var calculator = new ElectricityCalculator();
        var parameters = new ElectricityCalculationParameters(yearlyConsumption);

        var result = calculator.Calculate(basicElectricity, parameters);

        Assert.AreEqual("Product A", result.Name);
        Assert.AreEqual((decimal)annualCosts, result.AnnualCosts);
    }

    [TestMethod]
    [DataRow(3500, 800)]
    [DataRow(4500, 950)]
    public void GivenPackagedElectricity_WhenCalculated_ReturnsExpectedResult(int yearlyConsumption, float annualCosts)
    {
        var basicElectricity = new PackagedElectricity("Product B", 4000, 800, 30);

        var calculator = new ElectricityCalculator();
        var parameters = new ElectricityCalculationParameters(yearlyConsumption);

        var result = calculator.Calculate(basicElectricity, parameters);

        Assert.AreEqual("Product B", result.Name);
        Assert.AreEqual((decimal)annualCosts, result.AnnualCosts);
    }
}