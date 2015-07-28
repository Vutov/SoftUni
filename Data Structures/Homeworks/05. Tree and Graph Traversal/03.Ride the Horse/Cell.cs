namespace _03.Ride_the_Horse
{
    public struct Cell
    {
        public Cell(int x, int y, int value = 1) : this()
        {
            this.X = x;
            this.Y = y;
            this.Value = value;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Value { get; set; }
    }
}
