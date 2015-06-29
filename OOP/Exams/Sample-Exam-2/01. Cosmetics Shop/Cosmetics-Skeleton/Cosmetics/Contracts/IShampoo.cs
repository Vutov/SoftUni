namespace Cosmetics.Contracts
{
    using Common;

    public interface IShampoo : IProduct
    {
        uint Milliliters { get; }

        UsageType Usage { get; }
    }
}