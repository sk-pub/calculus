using Calculus.Api.Products;
using System.Text.Json;

namespace Calculus.Api.Tests.Unit.Products;

[TestClass]
public class PackagedElectricityTest
{
    [TestMethod]
    public void GivenJson_WhenDeserialized_CreatesPackagedElectricity()
    {
        const string json = @"{""name"": ""Product B"", ""type"": 2, ""includedKwh"": 4000, ""baseCost"": 800, ""additionalKwhCost"": 30}";

        var packagedElectricity = JsonSerializer.Deserialize<PackagedElectricity>(json);

        Assert.IsNotNull(packagedElectricity);
        Assert.AreEqual("Product B", packagedElectricity.Name);
        Assert.AreEqual(4000m, packagedElectricity.IncludedKwh);
        Assert.AreEqual(800m, packagedElectricity.BaseCost);
        Assert.AreEqual(0.30m, packagedElectricity.AdditionalKwhCost);
    }
}