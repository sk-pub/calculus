using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Calculus.Api.Providers;

public class ElectricityTariffProvider : IDataProvider
{
    private readonly HttpClient _httpClient;

    public ElectricityTariffProvider(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IReadOnlyList<IProduct>> GetProducts()
    {
        using var response = await _httpClient.GetAsync(string.Empty);
        using var jsonStream = await response.Content.ReadAsStreamAsync();

        var jsonObjects = await JsonSerializer.DeserializeAsync<JsonObject[]>(jsonStream);

        if (jsonObjects == null)
        {
            return Array.Empty<IProduct>();
        }

        var products = new List<IProduct>();

        foreach (var jsonObject in jsonObjects)
        {
            var typeValue = jsonObject["type"];
            if (typeValue == null)
            {
                throw new JsonException();
            }

            var productTypeId = typeValue.GetValue<int>();
            if (!ProductRegistry.Products.TryGetValue(productTypeId, out var productType))
            {
                throw new NotSupportedException();
            }

            var product = JsonSerializer.Deserialize(jsonObject, productType) as IProduct;
            if (product == null)
            {
                throw new NotSupportedException();
            }

            products.Add(product);
        }

        return products;
    }
}
