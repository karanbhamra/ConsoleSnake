using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Threading;

namespace TerminalSnake
{
    class Program
    {
        static Random gen = new Random();

        static int frameHeight = 30;
        static int frameWidth = 130;
        private static int score = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to begin.");

            Snake head = new Snake(new Vector2(gen.Next(2, frameWidth - 2), gen.Next(2, frameHeight - 2)), "8");

            List<Snake> snake = new List<Snake>();
            snake.Add(head);

            Food food = new Food(new Vector2(gen.Next(2, frameWidth - 2), gen.Next(2, frameHeight - 2)));

            while (head.IsAlive)
            {
                Clear();

                DisplayFrame(frameWidth, frameHeight, "#");
                
                for (int i = snake.Count - 1; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        KeyboardInput(head);
                        head.Move();
                    }
                    else
                    {
                        Snake prev = snake[i - 1];

                        Snake current = snake[i];

                        current.Pos = prev.Pos;
                    }
                    
                    snake[i].Draw();
                }

                head.BoundsCheck(frameWidth, frameHeight);

                FoodEatCheck(snake, food);
                
                food.Draw();
                DebugInfo(0, frameHeight + 1, head);


                Thread.Sleep(100);
            }

            GameOver(frameWidth, frameHeight);
        }

        private static void FoodEatCheck(List<Snake> snake, Food food)
        {
            if (snake[0].Pos == food.Pos)
            {
                food.NewLocation(new Vector2(gen.Next(2, frameWidth - 2), gen.Next(2, frameHeight - 2)));
                Vector2 newSnakePos = new Vector2(snake[snake.Count - 1].Pos.X +1, snake[snake.Count -1].Pos.Y);
                Snake newPiece = new Snake(newSnakePos, "0");
                snake.Add(newPiece);
                score++;
            }
        }

        private static void GameOver(int width, int height)
        {
            Clear();
            DisplayFrame(width, height, "#");
            Console.SetCursorPosition(width/2, height/2);
            Console.WriteLine("Game Over!");
        }

        private static void KeyboardInput(Snake snake)
        {
            if (Console.KeyAvailable)
            {
                Console.CursorVisible = false;

                var key = Console.ReadKey(true);

                snake.UpdateDirection(key.Key);
            }
        }

        private static void Clear()
        {
            Console.Clear();
        }

        private static void DisplayFrame(int width, int height, string borderChar)
        {
            Console.SetCursorPosition(0, 0);
            // draw a hollow rect of the given width and height

            for (int line = 0; line < height; line++)
            {
                if (line == 0 || line == height - 1)
                {
                    for (int col = 0; col < width; col++)
                    {
                        Console.Write(borderChar);
                    }
                }
                else
                {
                    for (int col = 0; col < width; col++)
                    {
                        if (col == 0 || col == width - 1)
                        {
                            Console.Write(borderChar);
                        }
                        else
                        {
                            Console.Write(' ');
                        }
                    }
                }

                Console.WriteLine();
            }
        }

        private static void DebugInfo(int x, int y, Snake s)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine($"Karan's Snake Game");
            Console.WriteLine($"Position: {s.Pos}, Direction: {s.CurrentDirection}, Score: {score}");
        }
    }
}