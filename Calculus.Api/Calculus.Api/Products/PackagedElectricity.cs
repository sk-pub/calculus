using System.Text.Json.Serialization;

namespace Calculus.Api.Products;

public class PackagedElectricity : IProduct
{
    [JsonConstructor]
    public PackagedElectricity(string name, decimal includedKwh, decimal baseCost, decimal additionalKwhCost)
    {
        Name = name;

        IncludedKwh = includedKwh;

        // Comes in €
        BaseCost = baseCost;

        // Comes in ¢
        AdditionalKwhCost = additionalKwhCost / 100;
    }

    [JsonPropertyName("name")]
    public string Name { get; }

    [JsonPropertyName("includedKwh")]
    public decimal IncludedKwh { get; }

    [JsonPropertyName("baseCost")]
    public decimal BaseCost { get; }

    [JsonPropertyName("additionalKwhCost")]
    public decimal AdditionalKwhCost { get; }
}
