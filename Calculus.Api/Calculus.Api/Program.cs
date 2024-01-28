using Calculus.Api;
using Calculus.Api.Calculators.Electricity;
using Calculus.Api.Providers;
using Microsoft.Extensions.Options;
using Polly;

var builder = WebApplication.CreateBuilder(args);

// Config options
builder.Services.Configure<ProviderOptions>(builder.Configuration.GetSection(nameof(ProviderOptions)));

// CORS
builder.Services.AddCors();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// External data source
builder.Services.AddHttpClient<IDataProvider, ElectricityTariffProvider>(
    (serviceProvider, client) =>
    {
        var providerOptions = serviceProvider.GetService<IOptionsMonitor<ProviderOptions>>();
        if (providerOptions == null)
        {
            throw new Exception("No provider options found");
        }
        var apiUrl = providerOptions.CurrentValue.ElectricityTariffProviderUrl;
        if (apiUrl == null)
        {
            throw new Exception($"Empty {nameof(ProviderOptions.ElectricityTariffProviderUrl)}");
        }

        client.BaseAddress = apiUrl;
    })
    .AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(100)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// TODO: Generate endpoints for each calculator
app.MapPost("/electricity", async (ElectricityCalculationParameters parameters, IDataProvider dataProvider) =>
{
    var calculator = new ElectricityCalculator();

    var products = await dataProvider.GetProducts();

    var results = CalculationResultList.Create(products, calculator, parameters);
    return results;
})
.WithName("CalculateElectricity")
.WithOpenApi();

app.UseCors((cors) =>
{
    cors.AllowAnyOrigin();
    cors.AllowAnyHeader();
});

app.Run();
