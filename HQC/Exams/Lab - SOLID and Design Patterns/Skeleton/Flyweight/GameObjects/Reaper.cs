namespace ReaperInvasion.GameObjects
{
    using Contracts;
    using UI;

    public class Reaper : IRenderable
    {
        public Reaper(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Type = AssetType.Reaper;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public AssetType Type { get; set; }
    }
}
