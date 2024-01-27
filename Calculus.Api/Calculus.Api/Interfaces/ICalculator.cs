namespace Calculus.Api.Interfaces;

public interface ICalculator<TParameters, TResult>
    where TParameters : ICalculationParameters
    where TResult : ICalculationResult
{
    HashSet<Type> SupportedProducts { get; }

    TResult Calculate(IProduct product, TParameters parameters);
}
