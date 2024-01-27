using System.Text.Json.Serialization;

namespace Calculus.Api.Products;

public class BasicElectricity : IProduct
{
    [JsonConstructor]
    public BasicElectricity(string name, decimal baseCost, decimal additionalKwhCost)
    {
        Name = name;

        // Comes in €
        BaseCost = baseCost;

        // Comes in ¢
        AdditionalKwhCost = additionalKwhCost / 100;
    }

    [JsonPropertyName("name")]
    public string Name { get; }

    [JsonPropertyName("baseCost")]
    public decimal BaseCost { get; }

    [JsonPropertyName("additionalKwhCost")]
    public decimal AdditionalKwhCost { get; }
}
