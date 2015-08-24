namespace Battleships.Models
{
    using System;

    public class Ship
    {
        public int Id { get; set; }

        public int PositionX { get; set; }

        public int PositionY { get; set; }

        public Guid GameId { get; set; }

        public virtual Game Game { get; set; }
    }
}
