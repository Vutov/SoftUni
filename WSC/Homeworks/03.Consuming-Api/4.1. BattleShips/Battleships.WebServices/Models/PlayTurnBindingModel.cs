namespace Battleships.WebServices.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PlayTurnBindingModel
    {
        [Required(ErrorMessage = "GameId is required!")]
        public string GameId { get; set; }

        public int PositionX { get; set; }

        public int PositionY { get; set; }
    }
}