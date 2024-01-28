namespace Calculus.Api.Interfaces
{
    public interface IDataProvider
    {
        Task<IReadOnlyList<IProduct>> GetProducts();
    }
}
