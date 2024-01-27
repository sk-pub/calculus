namespace Calculus.Api;

public static class CalculationResultList
{
    public static IReadOnlyList<TResult> Create<TParameters, TResult>(
        IEnumerable<IProduct> products,
        ICalculator<TParameters, TResult> calculator,
        TParameters parameters)
            where TParameters : ICalculationParameters
            where TResult : ICalculationResult
    {
        var results = new List<TResult>();

        foreach (var product in products)
        {
            if (!calculator.SupportedProducts.Contains(product.GetType()))
            {
                continue;
            }

            var result = calculator.Calculate(product, parameters);
            results.Add(result);
        }

        return results;
    }
}
