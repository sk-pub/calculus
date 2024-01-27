using Calculus.Api;
using Calculus.Api.Calculators.Electricity;
using Calculus.Api.Products;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// TODO: Generate endpoints for each calculator
app.MapPost("/electricity", (ElectricityCalculationParameters parameters) =>
{
    var calculator = new ElectricityCalculator();

    // TODO: Get the json from an external provider
    const string json = @"[
{""name"": ""Product A"", ""type"": 1, ""baseCost"": 5, ""additionalKwhCost"": 22},
{""name"": ""Product B"", ""type"": 2, ""includedKwh"": 4000, ""baseCost"": 800, ""additionalKwhCost"": 30}
]";

    // TODO: Get products from the json
    IEnumerable<IProduct> products =
    [
        new BasicElectricity("Product A", 5, 22),
        new PackagedElectricity("Product B", 4000, 800, 30)
    ];

    var results = CalculationResultList.Create(products, calculator, parameters);
    return results;
})
.WithName("CalculateElectricity")
.WithOpenApi();

app.Run();
