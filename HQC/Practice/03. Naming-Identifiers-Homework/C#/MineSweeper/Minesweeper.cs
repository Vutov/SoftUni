using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweeper
{
    public class Minesweeper
    {
        public class Scores
        {
            private string name;

            private int points;

            public string Player
            {
                get
                {
                    return name;
                }

                set
                {
                    name = value;
                }
            }

            public int Score
            {
                get
                {
                    return points;
                }

                set
                {
                    points = value;
                }
            }

            public Scores()
            {
            }

            public Scores(string name, int points)
            {
                this.Player = name;
                this.Score = points;
            }
        }

        private static void Main(string[] args)
        {
            string command = string.Empty;
            char[,] field = CreateField();
            char[,] bombs = CreateBombs();
            int bombCount = 0;
            bool exploded = false;
            List<Scores> scoreBoard = new List<Scores>(6);
            int row = 0;
            int col = 0;
            bool alive = true;
            const int maximumBombs = 35;
            bool gameOver = false;

            do
            {
                if (alive)
                {
                    Console.WriteLine(
                        "Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki."
                        + " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    DisplayField(field);
                    alive = false;
                }

                Console.Write("Daj red i kolona : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out col)
                        && row <= field.GetLength(0) && col <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        ShowScoreboard(scoreBoard);
                        break;
                    case "restart":
                        field = CreateField();
                        bombs = CreateBombs();
                        DisplayField(field);
                        exploded = false;
                        alive = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (bombs[row, col] != '*')
                        {
                            if (bombs[row, col] == '-')
                            {
                                NextTurn(field, bombs, row, col);
                                bombCount++;
                            }

                            if (maximumBombs == bombCount)
                            {
                                gameOver = true;
                            }
                            else
                            {
                                DisplayField(field);
                            }
                        }
                        else
                        {
                            exploded = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }

                if (exploded)
                {
                    DisplayField(bombs);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " + "Daj si niknejm: ", bombCount);
                    string name = Console.ReadLine();
                    Scores currentScore = new Scores(name, bombCount);
                    if (scoreBoard.Count < 5)
                    {
                        scoreBoard.Add(currentScore);
                    }
                    else
                    {
                        for (int i = 0; i < scoreBoard.Count; i++)
                        {
                            if (scoreBoard[i].score < currentScore.score)
                            {
                                scoreBoard.Insert(i, currentScore);
                                scoreBoard.RemoveAt(scoreBoard.Count - 1);
                                break;
                            }
                        }
                    }

                    scoreBoard.Sort((Scores r1, Scores r2) => r2.player.CompareTo(r1.player));
                    scoreBoard.Sort((Scores r1, Scores r2) => r2.score.CompareTo(r1.score));
                    ShowScoreboard(scoreBoard);

                    field = CreateField();
                    bombs = CreateBombs();
                    bombCount = 0;
                    exploded = false;
                    alive = true;
                }

                if (gameOver)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    DisplayField(bombs);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string name = Console.ReadLine();
                    Scores score = new Scores(name, bombCount);
                    scoreBoard.Add(score);
                    ShowScoreboard(scoreBoard);
                    field = CreateField();
                    bombs = CreateBombs();
                    bombCount = 0;
                    gameOver = false;
                    alive = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void ShowScoreboard(List<Scores> score)
        {
            Console.WriteLine("\nTo4KI:");
            if (score.Count > 0)
            {
                for (int i = 0; i < score.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, score[i].player, score[i].score);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void NextTurn(char[,] field, char[,] bombs, int row, int col)
        {
            char bombCount = CountBombs(bombs, row, col);
            bombs[row, col] = bombCount;
            field[row, col] = bombCount;
        }

        private static void DisplayField(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] CreateBombs()
        {
            int rows = 5;
            int cols = 10;
            char[,] playField = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    playField[i, j] = '-';
                }
            }

            List<int> r3 = new List<int>();
            while (r3.Count < 15)
            {
                Random rng = new Random();
                int rand = rng.Next(50);
                if (!r3.Contains(rand))
                {
                    r3.Add(rand);
                }
            }

            foreach (int i2 in r3)
            {
                int col = i2 / cols;
                int row = i2 % cols;
                if (row == 0 && i2 != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                playField[col, row - 1] = '*';
            }

            return playField;
        }

        private static void Calculations(char[,] field)
        {
            int col = field.GetLength(0);
            int row = field.GetLength(1);

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (field[i, j] != '*')
                    {
                        char bombsCount = CountBombs(field, i, j);
                        field[i, j] = bombsCount;
                    }
                }
            }
        }

        private static char CountBombs(char[,] field, int row, int col)
        {
            int bombsCount = 0;
            int totalRows = field.GetLength(0);
            int totalCols = field.GetLength(1);

            if (row - 1 >= 0)
            {
                if (field[row - 1, col] == '*')
                {
                    bombsCount++;
                }
            }

            if (row + 1 < totalRows)
            {
                if (field[row + 1, col] == '*')
                {
                    bombsCount++;
                }
            }

            if (col - 1 >= 0)
            {
                if (field[row, col - 1] == '*')
                {
                    bombsCount++;
                }
            }

            if (col + 1 < totalCols)
            {
                if (field[row, col + 1] == '*')
                {
                    bombsCount++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (field[row - 1, col - 1] == '*')
                {
                    bombsCount++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < totalCols))
            {
                if (field[row - 1, col + 1] == '*')
                {
                    bombsCount++;
                }
            }

            if ((row + 1 < totalRows) && (col - 1 >= 0))
            {
                if (field[row + 1, col - 1] == '*')
                {
                    bombsCount++;
                }
            }

            if ((row + 1 < totalRows) && (col + 1 < totalCols))
            {
                if (field[row + 1, col + 1] == '*')
                {
                    bombsCount++;
                }
            }

            return char.Parse(bombsCount.ToString());
        }
    }
}