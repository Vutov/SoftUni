using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthDash
{
    class LabyrinthDash
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            var maze = new List<List<char>>();
            for (int i = 0; i < rows; i++)
            {
                maze.Add(Console.ReadLine().ToList());
            }

            var commands = Console.ReadLine();
            var lives = 3;
            var x = 0;
            var y = 0;
            char cell = '.';
            var gameOver = false;
            var moves = 0;

            foreach (var command in commands)
            {
                switch (command)
                {
                    case '>':
                        x++;
                        try
                        {
                            cell = maze[y][x];
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("Fell off a cliff! Game Over!");
                            gameOver = true;
                            break;
                        }
                        switch (cell)
                        {
                            case '.':
                                Console.WriteLine("Made a move!");
                                break;
                            case '@':
                            case '#':
                            case '*':
                                lives--;
                                Console.WriteLine("Ouch! That hurt! Lives left: {0}",
                                    lives);
                                break;
                            case '|':
                            case '_':
                                x--;
                                Console.WriteLine("Bumped a wall.");
                                moves--;
                                break;
                            case '$':
                                lives++;
                                maze[y][x] = '.';
                                Console.WriteLine("Awesome! Lives left: {0}",
                                    lives);
                                break;
                            case ' ':
                                Console.WriteLine("Fell off a cliff! Game Over!");
                                gameOver = true;
                                break;
                        }

                        break;
                    case '<':
                        x--;
                        try
                        {
                            cell = maze[y][x];
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("Fell off a cliff! Game Over!");
                            gameOver = true;
                            break;
                        }
                        switch (cell)
                        {
                            case '.':
                                Console.WriteLine("Made a move!");
                                break;
                            case '@':
                            case '#':
                            case '*':
                                lives--;
                                Console.WriteLine("Ouch! That hurt! Lives left: {0}",
                                    lives);
                                break;
                            case '|':
                            case '_':
                                x++;
                                Console.WriteLine("Bumped a wall.");
                                moves--;
                                break;
                            case '$':
                                lives++;
                                maze[y][x] = '.';
                                Console.WriteLine("Awesome! Lives left: {0}",
                                    lives);
                                break;
                            case ' ':
                                Console.WriteLine("Fell off a cliff! Game Over!");
                                gameOver = true;
                                break;
                        }

                        break;
                    case '^':
                        y--;
                        try
                        {
                            cell = maze[y][x];
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("Fell off a cliff! Game Over!");
                            gameOver = true;
                            break;
                        }
                        switch (cell)
                        {
                            case '.':
                                Console.WriteLine("Made a move!");
                                break;
                            case '@':
                            case '#':
                            case '*':
                                lives--;
                                Console.WriteLine("Ouch! That hurt! Lives left: {0}",
                                    lives);
                                break;
                            case '|':
                            case '_':
                                y++;
                                Console.WriteLine("Bumped a wall.");
                                moves--;
                                break;
                            case '$':
                                lives++;
                                maze[y][x] = '.';
                                Console.WriteLine("Awesome! Lives left: {0}",
                                    lives);
                                break;
                            case ' ':
                                Console.WriteLine("Fell off a cliff! Game Over!");
                                gameOver = true;
                                break;
                        }

                        break;
                    case 'v':
                        y++;
                        try
                        {
                            cell = maze[y][x];
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("Fell off a cliff! Game Over!");
                            gameOver = true;
                            break;
                        }
                        switch (cell)
                        {
                            case '.':
                                Console.WriteLine("Made a move!");
                                break;
                            case '@':
                            case '#':
                            case '*':
                                lives--;
                                Console.WriteLine("Ouch! That hurt! Lives left: {0}",
                                    lives);
                                break;
                            case '|':
                            case '_':
                                y--;
                                Console.WriteLine("Bumped a wall.");
                                moves--;
                                break;
                            case '$':
                                lives++;
                                maze[y][x] = '.';
                                Console.WriteLine("Awesome! Lives left: {0}",
                                    lives);
                                break;
                            case ' ':
                                Console.WriteLine("Fell off a cliff! Game Over!");
                                gameOver = true;
                                break;
                        }

                        break;
                }

                moves++;

                if (lives == 0)
                {
                    Console.WriteLine("No lives left! Game Over!");
                    break;
                }

                if (gameOver)
                {
                    break;
                }
            }

            Console.WriteLine("Total moves made: {0}", moves);
        }
    }
}
