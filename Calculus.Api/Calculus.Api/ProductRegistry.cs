using Calculus.Api.Products;

namespace Calculus.Api
{
    public static class ProductRegistry
    {
        public static Dictionary<int, Type> Products = new Dictionary<int, Type>
        {
            { 1, typeof(BasicElectricity) },
            { 2, typeof(PackagedElectricity) }
        };
    }
}
