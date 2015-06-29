namespace Cosmetics.Contracts
{
    using Common;

    public interface IProduct
    {
        string Name { get; }

        string Brand { get; }

        decimal Price { get; }

        GenderType Gender { get; }

        string Print();
    }
}
