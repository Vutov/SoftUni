namespace ReaperInvasion.Contracts
{
    using UI;

    public interface IRenderable
    {
        int X { get; }

        int Y { get; }

        AssetType Type { get; }
    }
}
