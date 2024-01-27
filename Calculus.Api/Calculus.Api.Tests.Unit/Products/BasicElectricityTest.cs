using Calculus.Api.Products;
using System.Text.Json;

namespace Calculus.Api.Tests.Unit.Products;

[TestClass]
public class BasicElectricityTest
{
    [TestMethod]
    public void GivenJson_WhenDeserialized_CreatesBasicElectricity()
    {
        const string json = @"{""name"": ""Product A"", ""type"": 1, ""baseCost"": 5, ""additionalKwhCost"": 22}";

        var basicElectricity = JsonSerializer.Deserialize<BasicElectricity>(json);

        Assert.IsNotNull(basicElectricity);
        Assert.AreEqual("Product A", basicElectricity.Name);
        Assert.AreEqual(5m, basicElectricity.BaseCost);
        Assert.AreEqual(0.22m, basicElectricity.AdditionalKwhCost);
    }
}