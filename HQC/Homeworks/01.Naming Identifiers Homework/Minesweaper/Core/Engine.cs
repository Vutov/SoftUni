namespace Application2.Core
{
    public class Engine
    {
        public static void NextTurn(char[,] field, char[,] bombs, int row, int col)
        {
            var numberOfBombs = SeedGame.GetNumberOfBombs(bombs, row, col);
            bombs[row, col] = numberOfBombs;
            field[row, col] = numberOfBombs;
        }
    }
}
