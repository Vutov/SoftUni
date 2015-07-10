namespace Application2
{
    using System;
    using System.Collections.Generic;
    using Core;
    using UI;

    public class Minesweeper
    {
        private static void Main()
        {
            const int MaxCommandInputLen = 3;
            const int MaxCells = 35;

            string command;
            char[,] gameField = SeedGame.CreateGameField();
            char[,] board = SeedGame.SetBoard();
            var champions = new List<Score>(6);
            var score = 0;
            var row = 0;
            var col = 0;

            var gameIsRunning = true;
            var gameWon = false;
            var gameOver = false;

            do
            {
                if (gameIsRunning)
                {
                    Console.WriteLine(
                        "Lets play Minesweeper. Test you luck in discovering cells without bombs."
                        + " Command 'top' shows the scoreboard, 'restart' resets the game, 'exit' quits the game!");
                    Draw.DrawInnerField(gameField);
                    gameIsRunning = false;
                }

                Console.Write("Row and Col please : ");
                command = Console.ReadLine().Trim();

                if (command.Length >= MaxCommandInputLen)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out col)
                        && row <= gameField.GetLength(0) && col <= gameField.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        Draw.Scoreboard(champions);
                        break;
                    case "restart":
                        gameField = SeedGame.CreateGameField();
                        board = SeedGame.SetBoard();
                        Draw.DrawInnerField(gameField);
                        break;
                    case "exit":
                        Console.WriteLine("Bye!");
                        break;
                    case "turn":
                        if (board[row, col] != '*')
                        {
                            if (board[row, col] == '-')
                            {
                                Engine.NextTurn(gameField, board, row, col);
                                score++;
                            }

                            if (MaxCells == score)
                            {
                                gameWon = true;
                            }
                            else
                            {
                                Draw.DrawInnerField(gameField);
                            }
                        }
                        else
                        {
                            gameOver = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nInvalid command!\n");
                        break;
                }

                if (gameOver)
                {
                    Draw.DrawInnerField(board);
                    Console.Write("\nYou died with {0} score. " + "What is your name? ", score);
                    string name = Console.ReadLine();
                    Score t = new Score(name, score);
                    if (champions.Count < 5)
                    {
                        champions.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].CurrentScore < t.CurrentScore)
                            {
                                champions.Insert(i, t);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((r1, r2) => r2.PlayerName.CompareTo(r1.PlayerName));
                    champions.Sort((r1, r2) => r2.CurrentScore.CompareTo(r1.CurrentScore));
                    Draw.Scoreboard(champions);

                    gameField = SeedGame.CreateGameField();
                    board = SeedGame.SetBoard();
                    score = 0;
                    gameOver = false;
                    gameIsRunning = true;
                }

                if (gameWon)
                {
                    Console.WriteLine("\nCongratulations! You opened all 35 cells without dying!.");
                    Draw.DrawInnerField(board);
                    Console.WriteLine("What is your name? ");
                    string name = Console.ReadLine();
                    var bestScore = new Score(name, score);
                    champions.Add(bestScore);
                    Draw.Scoreboard(champions);
                    gameField = SeedGame.CreateGameField();
                    board = SeedGame.SetBoard();
                    score = 0;
                    gameWon = false;
                    gameIsRunning = true;
                }
            } 
            while (command != "exit");

            Console.WriteLine("Made in Bulgaria!");
            Console.Read();
        }
    }
}