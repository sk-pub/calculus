using Calculus.Api.Calculators.Electricity;
using Calculus.Api.Interfaces;
using Calculus.Api.Products;

namespace Calculus.Api.Tests.Unit.Products;

[TestClass]
public class CalculationResultListTest
{
    [TestMethod]
    public void GivenSupportedProducts_WhenCalculated_CreatesEqualLengthList()
    {

        IEnumerable<IProduct> products =
        [
            new BasicElectricity("Product A", 5, 22),
            new PackagedElectricity("Product B", 4000, 800, 30)
        ];

        var calculator = new ElectricityCalculator();
        var parameters = new ElectricityCalculationParameters(3500);

        var results = CalculationResultList.Create(products, calculator, parameters);

        Assert.IsNotNull(results);
        Assert.AreEqual(2, results.Count);

        foreach (var result in results)
        {
            Assert.IsInstanceOfType(result, typeof(ElectricityCalculationResult));
        }
    }

    [TestMethod]
    public void GivenPartiallySupportedProducts_WhenCalculated_CreatesSmallerList()
    {
        IEnumerable<IProduct> products =
        [
            A.Fake<IProduct>(),
            new BasicElectricity("Product A", 5, 22),
            A.Fake<IProduct>(),
            new PackagedElectricity("Product B", 4000, 800, 30),
            A.Fake<IProduct>()
        ];

        var calculator = new ElectricityCalculator();
        var parameters = new ElectricityCalculationParameters(3500);

        var results = CalculationResultList.Create(products, calculator, parameters);

        Assert.IsNotNull(results);
        Assert.AreEqual(2, results.Count);

        foreach (var result in results)
        {
            Assert.IsInstanceOfType(result, typeof(ElectricityCalculationResult));
        }
    }
}